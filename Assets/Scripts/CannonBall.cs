using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private TriggerParticles onBlockHit;
    [SerializeField] private TriggerParticles onGroundHit;

    private AudioSource source;
    private bool onImpact = false;
    void Start(){
        source = GetComponent<AudioSource>();
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
            source.Play();
            Invoke("Delete",1);
            onImpact = true;
        }
    }
        private void Delete(){
        Destroy(onBlockHit.gameObject);
        Destroy(onGroundHit.gameObject);
        Destroy(source);
        Destroy(this);
    }
}
