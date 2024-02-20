using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float attractionForce = 10f;
    private GameObject centerOfGravity;
    private Vector3 target;
    private bool hasHit = false;

    public void SetTarget(Vector3 newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        if (!hasHit)
        {
            MoveBullet();
        }
        ApplyGravity();
    }

    void MoveBullet()
    {
        float step = Time.deltaTime * 10f;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasHit)
        {
            hasHit = true;
            ContactPoint contact = collision.contacts[0];
            transform.position = contact.point;

            Rigidbody bulletRigidbody = gameObject.GetComponent<Rigidbody>();
            if (bulletRigidbody != null && !collision.gameObject.CompareTag("Player"))
            {
                bulletRigidbody.isKinematic = true;
                centerOfGravity = gameObject;
            }
            else {
                Destroy(gameObject);
            }
        }
    }

    void ApplyGravity()
    {
        if (centerOfGravity != null)
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("MovableObject");

            foreach (GameObject obj in objs)
            {
                ApplyForce(obj);
            }
        }
    }

    void ApplyForce(GameObject obj)
    {
        if (obj != centerOfGravity)
        {
            Vector3 forceDirection = (centerOfGravity.transform.position - obj.transform.position).normalized;
            obj.GetComponent<Rigidbody>().AddForce(forceDirection * attractionForce);
        }
    }
}
