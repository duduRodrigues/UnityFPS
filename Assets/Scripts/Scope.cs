using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour {

    public Animator animator;
    public GameObject defaultUI;
    public GameObject scopeUI;
    private bool isScoped = false;
    public GameObject weaponCamera;

    public Camera mainCamera;
    public int zoom = 10;
    private float defaultFOV;

	// Use this for initialization
	void Start () {
        defaultFOV = mainCamera.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = true;
            animator.SetBool("Scoping", true);
            StartCoroutine(OnScoped());
        }

        if (Input.GetButtonUp("Fire2"))
        {
            isScoped = false;
            animator.SetBool("Scoping", false);
            OnUnscoped();
        }
        

    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.25f);
        UpdateScopeUI();
    }


    void OnUnscoped()
    {
        UpdateScopeUI();
    }

    void UpdateScopeUI()
    {
        defaultUI.SetActive(!isScoped);
        scopeUI.SetActive(isScoped);
        weaponCamera.SetActive(!isScoped);

        if (isScoped)
            mainCamera.fieldOfView = defaultFOV / zoom;
        else
            mainCamera.fieldOfView = defaultFOV;
    }
}
