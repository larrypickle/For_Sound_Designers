using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Box")
        {
            Physics.gravity = new Vector3(0, -1.0f, 0);       
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Box")
        {
            
            Physics.gravity = new Vector3(0, 1.0f, 0);
            


        }
    }
}
