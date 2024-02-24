using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public Transform gunTransform;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public float bulletSpeed = 50f;
    public float maxRaycastDistance = 50f;
    public int attractiveBulletsAmmo = 10;
    public int repulsiveBulletsAmmo = 5;

    //1 = attractive, 2 = repulsive
    private int bulletType = 1;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bulletType == 1 && attractiveBulletsAmmo > 0)
            {
                Shoot();
                attractiveBulletsAmmo--;
            }
            else if (bulletType == 2 && repulsiveBulletsAmmo > 0)
            {
                Shoot();
                repulsiveBulletsAmmo--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchBulletType();
        }
    }

    void SwitchBulletType()
    {
        bulletType = (bulletType == 1) ? 2 : 1;
    }

    void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 target = ray.GetPoint(maxRaycastDistance);

        GameObject bulletPrefab = (bulletType == 1) ? bulletPrefab1 : bulletPrefab2;
        GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
        bullet.layer = LayerMask.NameToLayer("Bullets");
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