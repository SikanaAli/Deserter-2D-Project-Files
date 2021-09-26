using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Player : Character
{

    [SerializeField]
	private Stat health;

	[SerializeField]
	private int chance;

	[SerializeField]
	Vector3 playerPos;

	[SerializeField]
	private GameObject livesInfo;

	[SerializeField]
	private float displayLifeInfo ;

	private bool DisplayBoo = false;

	[SerializeField]
	private GameObject player;

    private Rigidbody2D myRidgidboody;


	[SerializeField]
	private Transform[] groundPoints;

	[SerializeField]
	private float groundRadius;

	[SerializeField]
	private LayerMask whatIsGround;

	private bool isGrounded;

	private bool jump;

	[SerializeField]
	private bool airControl;

	[SerializeField]
	private float jumpForce;

    [SerializeField]
    private GameObject missile;

	[SerializeField]
	private AudioSource coinSound;

	private float delay = 3;

	public static float mSoundStop;

    public GameObject Emitter;

	[SerializeField]
	private GameObject gameOver;


    private void Awake()
    {
        health.Initialize();
		mSoundStop = health.CurrentVal;
    }

	// Use this for initialization
	public override void Start () {
        base.Start();



		myRidgidboody = GetComponent<Rigidbody2D> ();

	}

	void Update (){
		
		HandleInput ();

		Blood ();



		

	}

	
	// Update is called once per frame
	void FixedUpdate () {



		isGrounded = IsGrounded ();

		float horizontal = Input.GetAxis ("Horizontal");

		HandeleMovement (horizontal);


		HandleLayers ();

		ResetValues ();

	

	
	}



	private void Blood(){

		mSoundStop = health.CurrentVal;
		chance = lives.NumLives;

		if (health.CurrentVal <= 0) {
			
			if (chance <= 0) {
				delay -= Time.deltaTime;
				gameOver.SetActive (true);


				myRidgidboody.constraints = RigidbodyConstraints2D.FreezePositionX;
				MyAnimator.Stop ();

				if (delay <= 0) {
					PlayerPrefs.SetInt ("playerScore", ScoreManager.score);
					SceneManager.LoadScene (5);
				}
			} else {
				chance -= 1;
				lives.NumLives = chance;
				health.CurrentVal = health.MaxVal;
				player.transform.position = playerPos;
				DisplayBoo = true;
				StartCoroutine (DisplayLifeText ());
			}

		}
	}

	private IEnumerator DisplayLifeText() {
		if (DisplayBoo == true) {
			Debug.Log ("In corutine");
			livesInfo.SetActive (true);
			yield return new WaitForSeconds (3);
			livesInfo.SetActive (false);
			DisplayBoo = false;
		}
	}



	private void HandeleMovement(float horizontal){

		if (myRidgidboody.velocity.y < 0) {
            MyAnimator.SetBool ("landing", true);
		}
		myRidgidboody.velocity = new Vector2(horizontal * playerSpeed,myRidgidboody.velocity.y);

		if (isGrounded && jump)
		{
			isGrounded = false;
			myRidgidboody.AddForce (new Vector2 (0, jumpForce));
			MyAnimator.SetTrigger ("jump");

		}

		Flip (horizontal);

        MyAnimator.SetFloat ("speed", Mathf.Abs (horizontal));



	}




	private void HandleInput()
	{
		if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Space))
		{
			jump = true;
		}
        if (Input.GetKeyDown(KeyCode.X))
        {
            health.CurrentVal -= 10;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            health.CurrentVal += 10;
        }
		if (Input.GetKeyDown(KeyCode.Joystick1Button5) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot(0);
        }
			
    }

  

	private void Flip(float horizontal){

		if (health.CurrentVal > 0) {

			if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
				ChangeDirection ();
			}
		}
	}

	private bool IsGrounded()
	{
		if (myRidgidboody.velocity.y <= 0) 
		{
			foreach (Transform point in groundPoints)
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);

				for (int i = 0; 1 < colliders.Length; i++) 
				{
					if (colliders[i].gameObject != gameObject) 
					{
                        MyAnimator.ResetTrigger ("jump");
                        MyAnimator.SetBool ("landing", false);
						return true;
					}
				}
			}
		}

		return false;

	}

	private void ResetValues(){
		jump = false;
	}
		

	private void HandleLayers(){

		if (!isGrounded) {
            MyAnimator.SetLayerWeight (1, 1);
		} else {
            MyAnimator.SetLayerWeight (1, 0);
		}
	}

    public void Shoot(int value)
    {
		if (Time.timeScale != 0) {
			if (health.CurrentVal > 0) {

				if (Ammo.ammo > 0) {

					if (facingRight) {
						GameObject tmp = (GameObject)Instantiate (missile, Emitter.transform.position, Quaternion.Euler (new Vector3 (0, 0, -90)));
						tmp.GetComponent<G_fire> ().Initialize (Vector2.right);
						Ammo.ammo -= 1;
					} else {
						GameObject tmp = (GameObject)Instantiate (missile, Emitter.transform.position, Quaternion.Euler (new Vector3 (0, 0, 90)));
						tmp.GetComponent<G_fire> ().Initialize (Vector2.left);
						Ammo.ammo -= 1;
					}
				}
			}
		}
	

			
			
    }



	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			health.CurrentVal -= 10;
		} else if (coll.gameObject.tag == "HealthUp") {
			health.CurrentVal += 20;
			Destroy (coll.gameObject);
		} else if (coll.gameObject.tag == "ammo") {
			Ammo.ammo += 20;
			Destroy (coll.gameObject);
		} else if (coll.gameObject.tag == "coin") {

			Destroy (coll.gameObject);
			coinSound.Play ();
			ScoreManager.score += 30;
		}
	}


	void OnBecameInvisible()
	{
		health.CurrentVal -= 100;
	}
}