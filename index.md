## Deserter 2D

Before i set out to create a video game as my **Final Year Project** i had always had a passion for games and was driven to figure out just how exactly they are created.

You will find some info about the project, a few `screen shots` and `code` samples

#### Aim

The aim is to yield the ability to create 2d games with Unity while at the same time gaining a better understanding of JavaScript and C# (C Sharp) in relation to game development.

#### Objective

- To assemble game characters with Crazy talk Animator
- To investigate the use of sprites and sprite sheets in 2D games
- To formulate and generate 2d game environments
- To construct a working game for the windows platform

#### Screen Shots

#### Code Samples
```c#
/*Camera Follow Script*/

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
```

```c#
/* Collision function that perfomrs deffernt actions based on what the player collides with */

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
```

![Image](/Page/Img/first.png) 

![Level 1](https://github.com/SikanaAli/Deserter-2D-Project-Files/blob/main/Page/Img/Level%201.jpg)

For more details see [GitHub Flavored Markdown](https://guides.github.com/features/mastering-markdown/).

### Jekyll Themes

Your Pages site will use the layout and styles from the Jekyll theme you have selected in your [repository settings](https://github.com/SikanaAli/Deserter-2D-Project-Files/settings/pages). The name of this theme is saved in the Jekyll `_config.yml` configuration file.

### Support or Contact

Having trouble with Pages? Check out our [documentation](https://docs.github.com/categories/github-pages-basics/) or [contact support](https://support.github.com/contact) and we’ll help you sort it out.
