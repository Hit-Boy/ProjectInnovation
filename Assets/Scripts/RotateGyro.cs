using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGyro : MonoBehaviour
{
    [SerializeField] private Transform _gyroBase;
    [SerializeField] private Transform _gyroBarrel;
    [SerializeField] private Transform _cannonBase;
    [SerializeField] private Transform _cannonBarrel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _gyroBarrel.rotation = _cannonBarrel.rotation;
        _gyroBase.rotation = _cannonBase.rotation;
    }
}
