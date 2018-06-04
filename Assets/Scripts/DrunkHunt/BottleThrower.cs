using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleThrower : MonoBehaviour {

    float counter = 0;
    public float delayToThrow = 5f;
    public GameObject bottle;

    void Start()
    {
        GameObject go = Instantiate(bottle, transform.position, transform.rotation);
     
        Destroy(go, 10);
    }

	// Update is called once per frame
	void Update () {
		if(Time.time - delayToThrow > counter)
        {
            counter = Time.time;
            GameObject go = Instantiate(bottle, transform.position, transform.rotation);

        }
	}
}
