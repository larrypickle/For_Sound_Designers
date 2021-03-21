using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableScripts : MonoBehaviour
{   //Useful if we want to disable specific time scripts in a scene
    public bool disableScript;

    private FPS fpsEnable;

    private MouseMovement mouseEnable;

    public float changeable;
    
    private TimeLoop[] scripts;
    void Start()
    {
        mouseEnable = GameObject.FindObjectOfType<MouseMovement>();
        fpsEnable = GetComponent<FPS>();
        disableScript = true;
    }

    // Update is called once per frame
    void Update()
    {
         // Change which script you wanna grab
        if (disableScript == true)
        {
            mouseEnable.enabled = false;
            fpsEnable.enabled = false;
            TimeLoop[] scripts = GameObject.FindObjectsOfType<TimeLoop>();
            foreach (TimeLoop script in scripts)
            {
                script.enabled = false;
            }
            StartCoroutine(DisableScript());
        }
    }

    IEnumerator DisableScript()
    {
        TimeLoop[] scripts = GameObject.FindObjectsOfType<TimeLoop>();
        yield return new WaitForSeconds(changeable);
        foreach (TimeLoop script in scripts)
        {
            script.enabled = true;
        }
        disableScript = false;
        fpsEnable.enabled = true;
        mouseEnable.enabled = true;

    }
}
