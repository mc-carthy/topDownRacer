using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	private Rigidbody2D rb;
	private float speedForce = 15f;
	private float brakingForce = -10f;
	private float torqueForce = 200f;
	private float driftFactorSticky = 0.65f;
	private float driftFactorSlippy = 1f;
	private float maxStickyVelocity = 2f;
	private float minStickyVelocity = 1f;

	private void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}

	private void FixedUpdate () {

		float driftFactor = driftFactorSticky;

		if (RightVelocity().magnitude > maxStickyVelocity) {
			driftFactor = driftFactorSlippy;
		}

		if (RightVelocity().magnitude < minStickyVelocity) {
			driftFactor = driftFactorSticky;
		}

		rb.velocity = ForwardVelocity () + RightVelocity() * driftFactor;

		// Debug.Log (RightVelocity ().magnitude);

		if (Input.GetButton ("Accelerate")) {
			rb.AddForce (transform.up * speedForce);
		}

		if (Input.GetButton ("Brake")) {
			rb.drag = 5f;
		} else {
			rb.drag = 1f;
		}

		float tf = Mathf.Lerp (0, torqueForce, rb.velocity.magnitude / 10);



		rb.angularVelocity = Input.GetAxisRaw("Horizontal") * -tf;

	}

	private Vector2 ForwardVelocity () {
		return (transform.up * Vector2.Dot (rb.velocity, transform.up));
	}

	private Vector2 RightVelocity () {
		return (transform.right * Vector2.Dot (rb.velocity, transform.right));
	}
}
