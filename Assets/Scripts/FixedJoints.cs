using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedJoints : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        FixedJoint joint = gameObject.AddComponent<FixedJoint>();
        joint.breakForce = 100;
        joint.breakTorque = 100;
        joint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
    }
}
