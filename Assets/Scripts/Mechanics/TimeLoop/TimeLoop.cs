using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeLoop : MonoBehaviour
{

    public float rewindCounter;

    private float holder;

    public float countDown;

    private bool rewindTime;

    private RewindEffect rewindEffect;

    public TextMeshProUGUI text;

    public bool debug;

    public List<LastPoint> positionData = new List<LastPoint> ();


    
    // Start is called before the first frame update
    void Start()
    {
      
        rewindEffect = GameObject.Find("Main Camera").GetComponent<RewindEffect>();
        rewindTime = true;

        holder = countDown;
    }

    void FixedUpdate()
    {
        // AT the end starts rewind 
        if(countDown < 0 && rewindTime == true)
                {
                    Rewind();
                    rewindEffect.RewindEffectStart();

                }

                else
                {
                    Record();
                    Time.timeScale = 1.0f;
                    rewindEffect.RewindEffectEnd();

                 }
    }

 void Update()
    {
        text.text = Mathf.RoundToInt(countDown).ToString();

        if (countDown > 0)
        {
            countDown -= Time.deltaTime;
            Debug.Log(countDown);

              
        }

        if(Input.GetKeyDown(KeyCode.R) && debug == true)
        {
            Application.LoadLevel(Application.loadedLevel);

        }



    }
    //Records objects positions VERY jank need to adjust
    void Record()
    {   if(positionData.Count > Mathf.Round(rewindCounter / Time.fixedDeltaTime)) //MathF rounds the int from deltatime
        {
            positionData.RemoveAt(positionData.Count - 1);
        }
        positionData.Insert(0, new LastPoint(transform.position, transform.rotation));
    }

    // Rewinds the positions uses LastPoint to store Vector3 and Quartion positions
    public void Rewind()
    {
        Debug.Log("Rewind Started");
        Time.timeScale = 4.5f;
        if (positionData.Count > 0)
        {
            LastPoint lastPosition = positionData[0];
            transform.position = lastPosition.position;
            transform.rotation = lastPosition.rotation;
            positionData.RemoveAt(0);
        }

        else
        {
            StopRewind();
            
        }
        
    }

    public void StartRewind()
    {
        rewindTime = true;
       
    }

    public void StopRewind()
    {
        rewindTime = false;
       
        StartCoroutine(ResetTime());

    }
     IEnumerator ResetTime()
    {
         
         yield return new WaitForSeconds(1);
        
         countDown = holder;
         rewindTime = true;
    }

   
}
