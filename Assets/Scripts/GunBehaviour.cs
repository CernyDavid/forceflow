using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public Transform gunTransform;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float maxRaycastDistance = 100f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 target = ray.GetPoint(maxRaycastDistance);

        GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.velocity = (target - gunTransform.position).normalized * bulletSpeed;
        }

        BulletBehaviour bb = bullet.GetComponent<BulletBehaviour>();

        if (bb != null)
        {
            bb.SetTarget(target);
        }
    }
}
