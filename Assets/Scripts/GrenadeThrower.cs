using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour {

    public float throwForce = 40f;
    public GameObject grenadePrefab;

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowGrenade();
        }	
	}

    void ThrowGrenade()
    {
        GameObject _grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody _rb = _grenade.GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
