using UnityEngine;
using System.Collections;

public class Enemy : Character {


    private IEnemyState currentState;

    public GameObject Target { get; set; }

   
    protected Rigidbody2D myRidgidboody;

    // Use this for initialization
    public override void Start () {
        base.Start();
        ChangeState(new IdleState());
        myRidgidboody.GetComponent<Rigidbody2D>();
    }
	

    

	// Update is called once per frame
	void Update () {
        currentState.Execute();

        HandleAttacks();

        LookAtTartget();
	}

    private void LookAtTartget()
    {
        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;
            if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
            {
                ChangeDirection();
            }
        }
    }

    public void ChangeState(IEnemyState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter(this);
    }

    private void HandleAttacks()
    {

    }


public void Move()
    {
        MyAnimator.SetFloat("speed", 1);

        transform.Translate(GetDirection() * (playerSpeed * Time.deltaTime));
    }

    public Vector2 GetDirection()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        currentState.OnTriggerEnter(other);
    }

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Missile")
			Destroy (coll.gameObject, 0.7f);

	}
}
