﻿using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	private Rigidbody2D rb;
	private float speedForce = 10f;
	private float torqueForce = 1f;

	private void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}

	private void FixedUpdate () {
		if (Input.GetButton ("Accelerate")) {
			rb.AddForce (transform.up * speedForce);
		}

		rb.AddTorque(Input.GetAxisRaw("Horizontal") * -torqueForce);
	}

}