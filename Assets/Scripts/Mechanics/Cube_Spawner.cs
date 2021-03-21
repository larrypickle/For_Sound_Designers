using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Spawner : MonoBehaviour
{
    public GameObject cube;
    
    public bool activeCube;
    
    private Vector3 originalPos;

    public float respawnTimer;

    public float respawnEnd;

    public Vector3 limit;
    void Start()
    {
        activeCube = false;

        originalPos = cube.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        respawnTimer += Time.deltaTime;
        
        if (cube.transform.position.y <= limit.y && respawnTimer >= respawnEnd)
        {
            cube.transform.position = originalPos;
            Debug.Log("Working");
            respawnTimer = 0;
        }
        else
        { 
          
          activeCube = false;
                  
            
        }

    }




}
