using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
	
	public GameObject enemyExp;
	public GameObject playerExp;
	public int pointsValue;
	private StoneGeneratorScript ganerator;
	private Rigidbody2D Enemy;
	public float speed;
	public float minSpeed;
	public float maxSpeed;
	//public float hp;

	void Start ()
	{
		Enemy = GetComponent<Rigidbody2D>();
		Rigidbody2D enemy = GetComponent<Rigidbody2D>();
		enemy.velocity = Vector2.left * speed;
		enemy.velocity = Vector2.left * Random.Range (minSpeed, maxSpeed);

		GameObject ganeratorObject=GameObject.FindWithTag("GameController");
		if (ganeratorObject != null) {
			ganerator = ganeratorObject.GetComponent <StoneGeneratorScript>();
		}
		if (ganeratorObject = null) {
			Debug.Log ("Не найден 'StoneGeneratorScript'");
		};
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
		if (other.tag == "Lazer") {
			Instantiate (enemyExp, other.transform.position,Quaternion.identity);
		}
		if (other.tag == "Player") {
			Instantiate (playerExp, other.transform.position,Quaternion.identity);
			ganerator.GameOver();
		}
		Instantiate (enemyExp, transform.position, Quaternion.identity);
		ganerator.AddScore (pointsValue);
		Destroy (gameObject);
		Destroy (other.gameObject);
	}
}
