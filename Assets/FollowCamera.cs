using UnityEngine;

using System.Collections;



public class FollowCamera : MonoBehaviour {



	public float interpVelocity;

	public float minDistance;

	public float followDistance;

	public GameObject target;

	public Vector3 offset;

	Vector3 targetPos;

	public bool bounds;

	public Vector3 minCameraPos;

	public Vector3 maxCameraPos;

	// Use this for initialization

	void Start () {

		targetPos = transform.position;

	}



	// Update is called once per frame

	void FixedUpdate () {

		if (target)

		{

			Vector3 posNoZ = transform.position;

			posNoZ.z = target.transform.position.z;



			Vector3 targetDirection = (target.transform.position - posNoZ);



			interpVelocity = targetDirection.magnitude * 5f;



			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 



			transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);


			if(bounds)
			{ 
				transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
					Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
					Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
			}



		}

	}

}