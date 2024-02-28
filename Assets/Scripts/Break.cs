using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    Rigidbody[] rbs;
    // Start is called before the first frame update
    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rbs) { 
            rb.isKinematic = true;
        }
        GetComponent<Rigidbody>().isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {

            foreach (Rigidbody rb in rbs) {
                rb.isKinematic = false;
            }
        }
    }
}
