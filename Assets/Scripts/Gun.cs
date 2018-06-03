using UnityEngine;

public class Gun : MonoBehaviour {

    public int damage = 10;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForceConstant = 10f;

    public Camera fpsCam;

    public ParticleSystem gunFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

	void Update () {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }	
	}

    void Shoot()
    {
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
}
