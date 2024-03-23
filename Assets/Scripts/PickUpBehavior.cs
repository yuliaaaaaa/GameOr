using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBehavior : MonoBehaviour
{
    public Outline script;

    private void Start()
    {
        script.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            script.enabled = true;

        }

        if (Input.GetKey(KeyCode.E))
        {
            
        }     

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            script.enabled = false;
        }
    }

    private void GetItem()
    {
        Destroy(gameObject);
    }
}
