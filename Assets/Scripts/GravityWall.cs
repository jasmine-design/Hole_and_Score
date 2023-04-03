using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWall : MonoBehaviour {
    public Vector3 gravityDirection = Vector3.down;
    public float gravityForce = 9.81f;

    private void OnTriggerStay(Collider other) {
        if (other.attachedRigidbody != null) {
            other.attachedRigidbody.AddForce(gravityDirection * gravityForce, ForceMode.Acceleration);
        }
    }
}