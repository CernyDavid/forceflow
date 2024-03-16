using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepulsiveBulletBehaviour : BulletBehaviour
{
    public float repulsionForce = 9.81f;
    public float repulsionRange = 10f; //meters

    protected override void ApplyForce(GameObject obj)
    {
        if (obj != centerOfGravity && Vector3.Distance(centerOfGravity.transform.position, obj.transform.position) <= repulsionRange)
        {
            Vector3 repelDirection = (obj.transform.position - centerOfGravity.transform.position).normalized;
            obj.GetComponent<Rigidbody>().AddForce(repelDirection * repulsionForce);
        }
    }
}
