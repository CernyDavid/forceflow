using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractiveBulletBehaviour : BulletBehaviour
{
    public float attractionForce = 9.81f;

    protected override void ApplyForce(GameObject obj)
    {
        if (obj != centerOfGravity)
        {
            Vector3 forceDirection = (centerOfGravity.transform.position - obj.transform.position).normalized;
            obj.GetComponent<Rigidbody>().AddForce(forceDirection * attractionForce);
        }
    }
}
