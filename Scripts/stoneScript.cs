using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneScript : MonoBehaviour {
	public float minSpeed;
	public float maxSpeed;
	public GameObject explosion;
	public GameObject playerExp;
	public int pointsValue;
	private StoneGeneratorScript ganerator;
	//public float hp;

	void Start ()
	{
		GameObject ganeratorObject=GameObject.FindWithTag("GameController");
		if (ganeratorObject != null) {
			ganerator = ganeratorObject.GetComponent <StoneGeneratorScript>();
		}
		if (ganeratorObject = null) {
			Debug.Log ("Не найден 'StoneGeneratorScript'");
		}
		Rigidbody2D stone = GetComponent<Rigidbody2D>();
		stone.velocity = Vector2.left * Random.Range (minSpeed, maxSpeed);


	
	}
	/*void MakeDamage (int damage) {
		hp = hp - damage;
		if (hp <= 0) {
			Destroy (gameObject);
		}
	}*/
	void OnBecameInvisible ()
	{ 
		Destroy (gameObject); 
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "GameAria") {
			return;
		}
		if (other.tag == "Enemy") {
			return;
		}
		//Instantiate (explosion, transform.position, Quaternion.identity);
		if (other.tag == "Player") {
			
			Instantiate (playerExp, other.transform.position,Quaternion.identity);
			ganerator.GameOver();
		}
		Instantiate (explosion, transform.position, Quaternion.identity);
		ganerator.AddScore (pointsValue);
		Destroy (gameObject);
		Destroy (other.gameObject);
	}
}


