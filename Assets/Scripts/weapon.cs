﻿using UnityEngine;

public class weapon : MonoBehaviour {

    public Transform firepoint;
    public GameObject bulletPrefab;
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }

}