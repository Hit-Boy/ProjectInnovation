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
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.tag == "Ball")
        Debug.Log(collision.impulse.magnitude);
        if(collision.impulse.magnitude > 100)
        {
            rb.isKinematic = true;
            GetComponent<BoxCollider>().enabled = false;
            foreach(Transform child in transform)
                if(!child.TryGetComponent<Rigidbody>(out Rigidbody rigid))
                    child.AddComponent<Rigidbody>();
        }
    }
}
