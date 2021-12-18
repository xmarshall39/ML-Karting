using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        KartController controller = other.transform.parent.GetComponentInChildren<KartController>();
        if (controller && controller.isHeuristic)
        {
            controller.ApplyBoost();
        }

        else
        {
            if (controller) print("lskf");
        }
    }
}
