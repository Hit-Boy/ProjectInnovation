using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private TriggerParticles onBlockHit;
    [SerializeField] private TriggerParticles onGroundHit;

    private bool onImpact = false;
    private float startTime;
    void OnEnable() {
        startTime = Time.time;
    }
    private void OnCollisionEnter(Collision collision) {
        if(!onImpact){
            if(collision.gameObject.tag == "Ground")
                onGroundHit.TriggerEventParticles();
            else 
                onBlockHit.TriggerEventParticles();
            transform.DetachChildren();
            onBlockHit.transform.eulerAngles = Vector3.zero;
            onGroundHit.transform.eulerAngles = Vector3.zero;
            Invoke("Delete",1);
            onImpact = true;
        }
    }
        private void Delete(){
        Destroy(onBlockHit.gameObject);
        Destroy(onGroundHit.gameObject);
        }

        private void FixedUpdate() {
            if (Time.time - startTime >= 10f) {
                Destroy(gameObject);
            }
        }
}
