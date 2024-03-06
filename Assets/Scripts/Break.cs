using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
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
        if(collision.gameObject.tag == "Ball")
        rb.isKinematic = false;
        if(collision.relativeVelocity.magnitude > 15)
        {
            foreach(Transform child in transform)
                if(!child.TryGetComponent<Rigidbody>(out Rigidbody rigid))
                    child.AddComponent<Rigidbody>();
        }
    }
}
