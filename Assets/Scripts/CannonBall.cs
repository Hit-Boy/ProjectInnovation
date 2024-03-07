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
        Destroy(this);

    }
}
