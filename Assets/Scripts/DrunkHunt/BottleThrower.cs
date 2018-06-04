using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleThrower : MonoBehaviour {

    float counter = 0;
    public float delayToThrow = 5f;
    public GameObject bottle;
    float timeToSelfDestruct = 15f;

    void Start()
    {
        float randRot = Random.Range(0, 30);
        GameObject go = Instantiate(bottle, transform.position, Quaternion.Euler(randRot, randRot%12, (randRot*12)%30));
     
        Destroy(go, timeToSelfDestruct);
    }

	// Update is called once per frame
	void Update () {
		if(Time.time - delayToThrow > counter)
        {
            counter = Time.time;
            float randRot = Random.Range(0, 30);
            GameObject go = Instantiate(bottle, transform.position, Quaternion.Euler(randRot, randRot % 12, (randRot * 12) % 30));
            Destroy(go, timeToSelfDestruct);
        }
	}
}
