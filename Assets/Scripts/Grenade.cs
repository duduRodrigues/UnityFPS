using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

	// Use this for initialization
	void Start () {
        countdown = delay;
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if(countdown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
	}

    void Explode()
    {
        // Show effect
        GameObject _explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(_explosion, 3f);

        // Get nearby objects
        Collider[] _collidersToDestroy = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider _nearbyObject in _collidersToDestroy)
        {
            Destructible _destructibleObject = _nearbyObject.GetComponent<Destructible>();
            if (_destructibleObject != null)
            {
                _destructibleObject.Destroy();
            }
        }

        Collider[] _collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider _nearbyObject in _collidersToMove)
        {
            Rigidbody _rb = _nearbyObject.GetComponent<Rigidbody>();
            if (_rb != null)
            {
                _rb.AddExplosionForce(force, transform.position, radius);

            } 
        }

        // Remove granade
        Destroy(gameObject);
        
    }
}
