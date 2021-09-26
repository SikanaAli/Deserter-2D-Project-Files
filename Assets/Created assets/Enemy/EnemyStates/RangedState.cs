using UnityEngine;
using System.Collections;
using System;

public class RangedState : IEnemyState
{

    private Enemy enemy;


    private float shootTimer;
    private float shootCoolDown = 1;
    private bool canShoot;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        shootBall();

        if (enemy.Target != null)
        {
            enemy.Move();
        }
        else
        {
            enemy.ChangeState(new IdleState());
        }
    }

    public void Exit()
    {
        
    }

    public void OnTriggerEnter(Collider2D other)
    {
        
    }

    public void shootBall()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootCoolDown)
        {
            canShoot = true;
            shootTimer = 0;
        }

        if (canShoot)
        {
            canShoot = false;
            enemy.MyAnimator.SetTrigger("shoot");
        }
    }
}
