using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepulsiveBulletBehaviour : BulletBehaviour
{
    public float repulsionForce = 15f;
    public float repulsionRange = 15f; //meters

    private GameObject rangeIndicator;
    public Material indicatorMaterial;

    protected override void ApplyForce(GameObject obj)
    {
        if (obj != centerOfGravity && Vector3.Distance(centerOfGravity.transform.position, obj.transform.position) <= repulsionRange)
        {
            Vector3 repelDirection = (obj.transform.position - centerOfGravity.transform.position).normalized;
            obj.GetComponent<Rigidbody>().AddForce(repelDirection * repulsionForce);
        }
    }

    private void CreateRangeIndicator()
    {
        rangeIndicator = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        if (indicatorMaterial != null)
        {
            rangeIndicator.GetComponent<Renderer>().material = indicatorMaterial;
        }
        rangeIndicator.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        rangeIndicator.GetComponent<Renderer>().receiveShadows = false;
        rangeIndicator.transform.localScale = new Vector3(repulsionRange * 2, repulsionRange * 2, repulsionRange * 2);
        rangeIndicator.transform.position = transform.position;
        Destroy(rangeIndicator.GetComponent<Collider>());
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        CreateRangeIndicator();
    }
}
