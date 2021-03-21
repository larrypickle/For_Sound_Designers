using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HazardCreator : MonoBehaviour
{
    public ParticleSystem particleVisual;
    
    TimeLoop timeStart;
    
    public bool isReverser;

    public bool isDisintegrater;

    BlackHole shootRelease;

    public void Start()
    {
  
    
    }

    public void Disintegrater(Collider other)
    {
        Destroy(other.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "BlackHole(Clone)")
        {
            if (isReverser == true)
            {
                timeStart = other.GetComponent<TimeLoop>();
                timeStart.Rewind();
            }

            if(isDisintegrater == true)
            {
                shootRelease = other.GetComponent<BlackHole>();
                shootRelease.enabled = false;
                StartCoroutine(TurnOn());
            }
        }
    }

    IEnumerator TurnOn()
    {
        yield return new WaitForSeconds(1);
        shootRelease.enabled = true;

    }


}
