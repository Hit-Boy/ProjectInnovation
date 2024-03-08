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
    private AudioSource source;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        ui = FindObjectOfType<UIManager>();
        source = GetComponent<AudioSource>();
    }
    void Update(){
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > _breakForce / 3) {
            rb.isKinematic = false;
            if (!_broken) {
                ui.OnBreak();
                Debug.Log(source.isPlaying);
                if (!source.isPlaying) {
                    source.Play();
                }

                _broken = true;
            }
        }
        if(collision.relativeVelocity.magnitude > _breakForce) {
            for (int i = 0; i < transform.childCount; i++) {
                if (!transform.GetChild(i).TryGetComponent<Rigidbody>(out Rigidbody rigid) && i % 4 == 0) {
                    transform.GetChild(i).AddComponent<Rigidbody>();
                }
            }

            Destroy(this);
        }
    }
}
