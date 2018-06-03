using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public int damage = 10;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForceConstant = 10f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;

    public ParticleSystem gunFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    public Animator animator;

    void Start()
    {
        currentAmmo = maxAmmo;    
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update () {

        if (isReloading)
            return;

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }	
	}

    void Shoot()
    {
        currentAmmo--;

        gunFlash.Play();
        RaycastHit _hit;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out _hit, range))
        {
            Debug.Log(_hit.transform.name);

            Target _target = _hit.transform.GetComponent<Target>();
            if(_target != null)
            {
                _target.TakeDamage(damage);
            }

            if(_hit.rigidbody != null)
            {
                _hit.rigidbody.AddForce(-_hit.normal * damage * impactForceConstant);
            }

            GameObject effect = Instantiate(impactEffect, _hit.point, Quaternion.LookRotation(_hit.normal));
            Destroy(effect, 1f);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime-.25f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
