using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AriaScript : MonoBehaviour {
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;
	void OnTriggerExit (Collider other){
		Destroy (other.gameObject);
	}
}
