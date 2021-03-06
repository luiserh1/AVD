﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletController : MonoBehaviour
{
    float fireForce;

    public void SetFireForce(float f)
    {
        this.fireForce = f;
    }

    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, 3f);
    }

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * fireForce , ForceMode.Impulse);
        //Debug.Log("Fire force: " + fireForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 16)
        {
            Destroy(gameObject);
        }
    }
}
