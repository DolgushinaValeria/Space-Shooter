﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

	public float speed;
	public float tileSize;
	private Vector2 startPosition;
	void Start () {
		startPosition = transform.position;
	}

	void Update () {

		float newPosition= Mathf.Repeat (Time.time * speed, tileSize);
		transform.position = startPosition + Vector2.left * newPosition;
	}
}
