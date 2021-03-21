using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReached : MonoBehaviour
{
    public Transform platformActivate;

    public float multiplyLength;
    public float cubeGained;

    public bool platformUp;

    public bool platformDown;

    public bool openDoor;

    public bool objectLanded1;

    public bool objectLanded2;


    void Start()
    {
        objectLanded1 = false;
        objectLanded2 = false;
    
    }

  


    void OnTriggerEnter(Collider col)
    {
        if(col.name == "Tess" && objectLanded1 == false)
        {   
            objectLanded1 = true;
            cubeGained += 1;
           
        }

         if(col.name == "Tess2" && objectLanded2 == false )
        {   
            objectLanded2 = true;
            cubeGained += 1;
        }

        if(objectLanded1 == true && objectLanded2 == true && cubeGained == 2)
        {   
            objectLanded1 = false;
            objectLanded2 = false;
            cubeGained = 0;
             platformActivate.Translate(Vector3.up * 14f, Space.World);
            Debug.Log("Yes");
        }

        
    }

  

  
}
