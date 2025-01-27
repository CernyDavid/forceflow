using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public Camera fpsCam;
    public Transform gunTransform;
    //public Transform gunPoint;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public float bulletSpeed = 50f;
    public float maxRaycastDistance = 100f;
    public int attractiveBulletsAmmo = 10;
    public int repulsiveBulletsAmmo = 10;

    //1 = attractive, 2 = repulsive
    private int bulletType = 1;
    
    public Material displayBlueMaterial;
    public Material displayRedMaterial;
    public int materialIndex = 0;

    private Renderer objRenderer;

    public AudioSource gunshotSound;
    public AudioSource bulletSwitchSound;

    private Animator animator;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        animator.ResetTrigger("Shoot");

        if (objRenderer == null || materialIndex < 0 || materialIndex >= objRenderer.materials.Length)
        {
            Debug.LogError("Renderer not found or material index out of bounds.");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bulletType == 1 && attractiveBulletsAmmo > 0)
            {
                attractiveBulletsAmmo--;
                Shoot();
            }
            else if (bulletType == 2 && repulsiveBulletsAmmo > 0)
            {
                repulsiveBulletsAmmo--;
                Shoot();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchBulletType();
        }
    }

    void SwitchBulletType()
    {
        bulletSwitchSound.Play();
        bulletType = (bulletType == 1) ? 2 : 1;
        if (objRenderer == null) return;
        Material[] currentMaterials = objRenderer.materials;
        currentMaterials[materialIndex] = (bulletType == 1) ? displayBlueMaterial : displayRedMaterial;
        objRenderer.materials = currentMaterials;
    }

    void Shoot()
    {
        gunshotSound.Play();
        animator.SetTrigger("Shoot");
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

        GameObject.FindGameObjectWithTag("UI").GetComponent<UI>().UpdateBulletCount();
    }
}
