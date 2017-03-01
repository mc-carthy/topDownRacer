using UnityEngine;

public class AdvancedCarController2D : MonoBehaviour {

	private Rigidbody2D rb;

    private void Awake ()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

}
