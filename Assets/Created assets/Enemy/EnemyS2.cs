using UnityEngine;
using System.Collections;

public class EnemyS2 : MonoBehaviour
{

    Transform target;
    Transform enemyTransform;
     float speed;
    private float rotationSpeed;
    private bool facingRight;

    void Start()
    {
        facingRight = true;
        //obtain the game object Transform
        enemyTransform = this.GetComponent<Transform>();
        GameObject gameobject = GameObject.FindGameObjectWithTag("player");
    }


    void Update()
    {

     
    }

    public void ChangeDirection()
    {
        facingRight = !facingRight;
        //transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }

}