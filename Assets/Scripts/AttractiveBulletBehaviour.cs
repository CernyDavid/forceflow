using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttractiveBulletBehaviour : BulletBehaviour
{
    public float attractionForce = 9.81f;
    public float attractionRange = 10f;

    private GameObject rangeIndicator;
    public Material indicatorMaterial;

    protected override void ApplyForce(GameObject obj)
    {
        if (obj != centerOfGravity && Vector3.Distance(centerOfGravity.transform.position, obj.transform.position) <= attractionRange)
        {
            Vector3 forceDirection = (centerOfGravity.transform.position - obj.transform.position).normalized;
            obj.GetComponent<Rigidbody>().AddForce(forceDirection * attractionForce);
            RepulsiveBulletBehaviour rbb = obj.GetComponent<RepulsiveBulletBehaviour>();
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
        rangeIndicator.transform.localScale = new Vector3(attractionRange * 2, attractionRange * 2, attractionRange * 2);
        rangeIndicator.transform.position = transform.position;
        Destroy(rangeIndicator.GetComponent<Collider>());
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        CreateRangeIndicator();
    }
}
