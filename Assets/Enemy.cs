using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{

    public Transform Player;
    public float speed = 0.5f;
    int maxDist = 10;
    int minDist = 5;
    public float speedIncrease = 1f;
    public float speedUpIncrement = 3f;
    void Start()
    {
        InvokeRepeating("SpeedUp", speedUpIncrement, speedUpIncrement);
    }

    void FixedUpdate()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= minDist)
        {

            transform.position += transform.forward * speed * Time.deltaTime;
            
            /*if (Vector3.Distance(transform.position, Player.position) <= MmxDist)
            {

            }*/

        }
    }

    private void SpeedUp()
    {
        speed += speedIncrease;
    }
}