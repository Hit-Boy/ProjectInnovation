using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Break : MonoBehaviour
{
    private float _breakForce = 0.8f;
    private Rigidbody rb;
    private UIManager ui;
    private bool _broken = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        ui = FindObjectOfType<UIManager>();
    }
    void Update(){
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > _breakForce / 3) {
            rb.isKinematic = false;
            if (!_broken) {
                ui.OnBreak();
                _broken = true;
            }
        }
        if(collision.relativeVelocity.magnitude > _breakForce) {
            foreach(Transform child in transform)
                if(!child.TryGetComponent<Rigidbody>(out Rigidbody rigid))
                    child.AddComponent<Rigidbody>();
            Destroy(this);
        }
    }
}
