using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandom : MonoBehaviour {
	
	public AriaScript Aria;
	public float tilt;
	public float dodge;
	public float smoothing;
	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;
	private Rigidbody2D rb;
	private float currentSpeed;
	private float targetManeuver;

	void Start ()
	{
		rb = GetComponent <Rigidbody2D> ();
		StartCoroutine(Evade());
	}

	IEnumerator Evade ()
	{
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
		while (true)
		{
			targetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}

	void FixedUpdate ()
	{
		float newManeuver = Mathf.MoveTowards (GetComponent<Rigidbody>().velocity.x, targetManeuver, smoothing * Time.deltaTime);
		GetComponent<Rigidbody2D>().velocity = new Vector3 (newManeuver, 0.0f);
		GetComponent<Rigidbody2D>().position = new Vector3
			(
				Mathf.Clamp(GetComponent<Rigidbody>().position.x, Aria.xMin, Aria.xMax), 
				0.0f, 
				Mathf.Clamp(GetComponent<Rigidbody>().position.y, Aria.yMin, Aria.yMax)
			);
				
	}
}
