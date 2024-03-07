using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] TriggerParticles onBlockHit;
    [SerializeField] TriggerParticles onGroundHit;
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Ground")
            onGroundHit.TriggerEventParticles();
        else 
            onBlockHit.TriggerEventParticles();
        transform.DetachChildren();
        Invoke("Delete",1);
        Destroy(this);
    }
        private void Delete(){
        Destroy(onBlockHit.gameObject);
        Destroy(onGroundHit.gameObject);
    }
}
