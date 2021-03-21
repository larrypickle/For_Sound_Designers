using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindEffect : MonoBehaviour
{
    private Animator anim;
 

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RewindEffectStart()
    {
        anim.SetBool("Isplaying", true);
       
    }

    public void RewindEffectEnd()
    {
        anim.SetBool("Isplaying", false);
       

    }
}
