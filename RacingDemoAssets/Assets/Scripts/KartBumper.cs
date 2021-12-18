using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartBumper : MonoBehaviour
{
    public Rigidbody sphere;
    public float forceModifier;
    private void OnCollisionEnter(Collision collision)
    {
        var impulse = collision.GetContact(0).normal * sphere.velocity.sqrMagnitude * forceModifier;
        impulse.y = 0;
        sphere.AddForceAtPosition(impulse, collision.GetContact(0).point, ForceMode.Impulse);

    }

}
