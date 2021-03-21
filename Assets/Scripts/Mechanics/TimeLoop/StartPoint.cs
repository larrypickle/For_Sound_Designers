using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{public Transform startPosition;

    public Transform player;

    public float rewindCounter = 10;
    public float countDown;

    private bool rewindTime;
        

    public List<LastPoint> positionData = new List<LastPoint> ();


    
    // Start is called before the first frame update
    void Start()
    {   
        countDown = 10;
    }

 

 void Update()
    {
        if(countDown >= 0)
        {
            countDown -= Time.deltaTime;
            Debug.Log(countDown);

              
        }

        if(countDown <= 0 && rewindTime)
                {
                    player.position = startPosition.position;
                    StartCoroutine(reset());
                
                }

    }

    IEnumerator reset()
    {
         
         yield return new WaitForSeconds(3); 

        
      
         countDown = 10;
    }
}
