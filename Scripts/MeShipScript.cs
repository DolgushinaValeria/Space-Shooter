using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeShipScript : MonoBehaviour {
	
	public float speed;
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;

	public GameObject bullet;
	public Transform Gun;
	private Rigidbody2D Spaceship;
	public float shotDelay;
	public float nextShot;
	void Start () {
		
		Spaceship = GetComponent<Rigidbody2D>();
	}

	void Update(){
		bool makeShot = Time.time > nextShot;
		if (Input.GetKeyDown(KeyCode.Space) && makeShot) {

			nextShot = Time.time + shotDelay;
			Instantiate (bullet, Gun.position, Quaternion.identity);
		}
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Rigidbody2D spaceship = GetComponent <Rigidbody2D>();

		Spaceship.velocity = new Vector2 (moveHorizontal* speed, moveVertical * speed);
		float xPosition = Mathf.Clamp (Spaceship.position.x, xMin, xMax);
		float yPosition = Mathf.Clamp (Spaceship.position.y, yMin, yMax);

		Spaceship.position = new Vector2 (xPosition, yPosition);
	}
}