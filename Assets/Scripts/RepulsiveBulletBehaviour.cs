using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepulsiveBulletBehaviour : BulletBehaviour
{
    public float repulsionForce = 9.81f;

    protected override void ApplyForce(GameObject obj)
    {
        if (obj != centerOfGravity)
        {
            Vector3 repelDirection = (obj.transform.position - centerOfGravity.transform.position).normalized;
            obj.GetComponent<Rigidbody>().AddForce(repelDirection * repulsionForce);
        }
    }
}
