using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField]
	private Transform car;
	private Vector3 startPos;

	private void Start () {
		startPos = transform.position;
	}

	private void Update () {
		Vector3 temp = startPos;
		temp.x = car.position.x;
		temp.y = car.position.y;
		transform.position = temp;
	}
}
