using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class TriggerParticles : MonoBehaviour
{
    [SerializeField] List<ParticleSystem> paticles;
    private void Update() {
        transform.eulerAngles = new Vector3(0,0,0);
    }
    public void TriggerEventParticles() {
        paticles.ForEach(x=>x.Play());

    }
    
}
