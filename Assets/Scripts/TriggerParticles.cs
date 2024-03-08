using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParticles : MonoBehaviour
{
    [SerializeField] List<ParticleSystem> particles;
    public void TriggerEventParticles() {
        particles.ForEach(x=>x.Play());
    }
    
}
