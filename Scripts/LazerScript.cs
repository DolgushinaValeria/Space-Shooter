using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour {

	public float force; 
	private Rigidbody2D Lazer; 
	private int damage; 
	void Start () { 

		GetComponent <Rigidbody2D>().velocity = Vector3.right * force; 
	} 
	void OnBecameInvisible ()
	{ 
		Destroy (gameObject); 
	}
	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.tag == "Enemy") {
			
			other.gameObject.SendMessage ("MakeDamage", damage, SendMessageOptions.DontRequireReceiver);

			Destroy (gameObject);
		}

	}}