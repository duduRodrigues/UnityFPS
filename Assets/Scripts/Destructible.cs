﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

    public GameObject destroyedVersion;

	public GameObject Destroy()
    {
        // Spawn a shattered object
        GameObject go = Instantiate(destroyedVersion, transform.position, transform.rotation);
        // Remove the current object
        Destroy(gameObject);
        
        return go;
    }
}
