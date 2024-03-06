using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Break : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 2)
            rb.isKinematic = false;
        if(collision.relativeVelocity.magnitude > 4)
        {
            foreach(Transform child in transform)
                if(!child.TryGetComponent<Rigidbody>(out Rigidbody rigid))
                    child.AddComponent<Rigidbody>();
        }
    }
}
