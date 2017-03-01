using UnityEngine;

public class AdvancedCarController3D : MonoBehaviour {

    [SerializeField]
    private GameObject chassis;
    [SerializeField]
    private GameObject wheelFL;
    [SerializeField]
    private GameObject wheelFR;
    [SerializeField]
    private GameObject wheelRL;
    [SerializeField]
    private GameObject wheelRR;

    [SerializeField]
    private float engineForce;
    [SerializeField]
    private float brakeStrength;
    [SerializeField]
    private float rollResistanceCoeffecient;
    [SerializeField]
    private float cD;
    [SerializeField]
    private float frontalArea;
    [SerializeField]
    private float airDensity;

    private Rigidbody chassisRb;

    private float dragCoeffecient;
    private Vector3 tractionForce;
    private Vector3 dragForce;
    private Vector3 rollingResistanceForce;
    private Vector3 brakingForce;
    private Vector3 unitHeading;
	

    private void Awake ()
    {
        chassisRb = chassis.GetComponent<Rigidbody> ();
        dragCoeffecient = 0.5f * cD * frontalArea * airDensity;
    }

    private void FixedUpdate ()
    {
        unitHeading = Vector3.forward;
        float currentEngineForce = engineForce * Mathf.Max (0, Input.GetAxis ("Vertical"));
        tractionForce = currentEngineForce * unitHeading;
        dragForce = dragCoeffecient * -(chassisRb.velocity * chassisRb.velocity.magnitude);
        rollingResistanceForce = dragCoeffecient * -chassisRb.velocity;
        brakingForce = chassisRb.velocity.normalized * brakeStrength * Mathf.Min (0, Input.GetAxis ("Vertical"));

        Vector3 totalLongitudinalForce = tractionForce + dragForce + rollingResistanceForce + brakingForce;
        chassisRb.AddForce (totalLongitudinalForce, ForceMode.Force);
    }

}
