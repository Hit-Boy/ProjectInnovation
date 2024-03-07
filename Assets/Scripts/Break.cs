using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Break : MonoBehaviour
{
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
        if(collision.relativeVelocity.magnitude > 1)
            rb.isKinematic = false;
        if(collision.relativeVelocity.magnitude > 3) {
            if(!_broken) {
                ui.OnBreak();
                _broken = true;
            }
            foreach(Transform child in transform)
                if(!child.TryGetComponent<Rigidbody>(out Rigidbody rigid))
                    child.AddComponent<Rigidbody>();
            Destroy(this);
        }
    }
}
