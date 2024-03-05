using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Break : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        rbs = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rbs) { 
            rb.isKinematic = true;
        }
        GetComponent<Rigidbody>().isKinematic = false;
=======
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.tag == "Ball")
        Debug.Log(collision.impulse.magnitude);
        if(collision.impulse.magnitude > 100)
        {
            rb.isKinematic = true;
            GetComponent<BoxCollider>().enabled = false;
            foreach(Transform child in transform)
                if(!child.TryGetComponent<Rigidbody>(out Rigidbody rigid))
                    child.AddComponent<Rigidbody>();
        }
    }
}
