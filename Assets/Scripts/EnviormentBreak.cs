using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnviormentBreak : MonoBehaviour
{
    private float _breakForce = 0.8f;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > _breakForce / 3)
            rb.isKinematic = false;
        if (collision.relativeVelocity.magnitude > _breakForce)
        {
            foreach (Transform child in transform)
                if (!child.TryGetComponent<Rigidbody>(out Rigidbody rigid))
                    child.AddComponent<Rigidbody>();
            Destroy(this);
        }
    }
}
