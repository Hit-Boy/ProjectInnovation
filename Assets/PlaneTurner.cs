using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PlaneTurner : MonoBehaviour {
    private ARPlaneManager planeManager;
    public ObjectSpawner objectSpawner;
    
    void Start() {
        planeManager = gameObject.GetComponent<ARPlaneManager>();
    }

    public void setPlaneManager(Boolean state) {
        planeManager.enabled = state;
    }

    private void Update() {
        if (objectSpawner.isPlaced == true) {
            setPlaneManager(false);
        }
    }
}
