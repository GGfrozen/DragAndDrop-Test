using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Poltergeist : MonoBehaviour
{
    [SerializeField] private Rigidbody rig;
    [SerializeField] private GameObject plane;

    private Vector3 velocity;

    private void Reset()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rig.WakeUp();
        
        velocity = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        if (velocity.magnitude > 0.01f)
        {
            rig.velocity = velocity;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(Vector3.up*5f,ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == plane)
        {
            return;
        }

        var targetMesh = other.gameObject.GetComponent<MeshFilter>().mesh;
        GetComponent<MeshFilter>().mesh = targetMesh;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject == plane)
        {
            plane.transform.Rotate(Time.deltaTime * 5f * Vector3.up);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject == plane)
        {
            return;
        }
        var targetMesh = other.gameObject.GetComponent<MeshRenderer>().material;
        GetComponent<MeshRenderer>().material = targetMesh; 
    }
}
