using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSetter : MonoBehaviour
{
    public Vector3 startPong;

    public Vector3 endPong;

    public float timeLapse;

    public float endLapse;

    public float movementSpeed;

    public GameObject platform;

    public Vector3 endPos;

    public int boxCounter;

    public float allowedBoxes;

    public bool moveUp;

    public bool moveSide;

    public List<GameObject> boxTracker;

    void Start()
    {
        timeLapse = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (boxTracker.Count == allowedBoxes)
        {   if (moveUp == true) // Move up does the move platform. The other function will do side to side.
            {
                MovePlatform();
            }

            if(moveSide == true)
            {
                MoveBackAndFourth();
               

            }
        }

        else if (boxTracker.Count > allowedBoxes)
        {
            boxTracker.RemoveAt(boxCounter);
        }
    }

    void MovePlatform()
    {
        platform.transform.position = Vector3.Lerp(platform.transform.position, endPos, movementSpeed * Time.deltaTime);
    }

    void MoveBackAndFourth()
    {
        platform.transform.position = Vector3.Lerp(startPong, endPong, Mathf.PingPong(Time.time * movementSpeed, 1.0f));

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.name == "Box")
        {
            boxTracker.Add(col.gameObject);
            moveUp = true; // This will be the unique identifer for the code to recognize which function to use
            
        }

        if(col.name == "BoxMover")
        {
           boxTracker.Add(col.gameObject);
           moveSide = true; //This will be the unique identifer for the code to recognize which function to use
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.name == "Box")
        {
            foreach (GameObject i in boxTracker)
            {
                boxTracker.Remove(i);
            }
        }
    }
}
