using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {

    public int selectedWeapon = 0;
    
	void Start () {
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }

        transform.GetChild(0).gameObject.SetActive(true);
    }
	
	void Update () {
        float d = Input.GetAxis("Mouse ScrollWheel");
        // scroll up
        if (d > 0f)
        {
            this.transform.GetChild(selectedWeapon).gameObject.SetActive(false);
            selectedWeapon = selectedWeapon == 0 ? transform.childCount - 1 : selectedWeapon - 1;
            this.transform.GetChild(selectedWeapon).gameObject.SetActive(true);
        }
        // scroll down
        else if (d < 0f)
        {
            this.transform.GetChild(selectedWeapon).gameObject.SetActive(false);
            selectedWeapon = selectedWeapon == (transform.childCount - 1) ? 0 : selectedWeapon + 1;
            this.transform.GetChild(selectedWeapon).gameObject.SetActive(true);
        }

        for(int i=49; i < 57 && (i-49) < transform.childCount; i++)
        {
            if (Input.GetKey((KeyCode)i))
            {
                this.transform.GetChild(selectedWeapon).gameObject.SetActive(false);
                selectedWeapon = i-49;
                this.transform.GetChild(selectedWeapon).gameObject.SetActive(true);
            }
        }
        
    }
}
