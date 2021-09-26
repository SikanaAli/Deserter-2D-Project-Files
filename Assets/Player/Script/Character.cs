using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {


    public Animator MyAnimator{ get; private set; }

    [SerializeField]
    protected float playerSpeed;

    protected bool facingRight;

    // Use this for initialization
    public virtual void Start () {
        facingRight = true;
        MyAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	
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
