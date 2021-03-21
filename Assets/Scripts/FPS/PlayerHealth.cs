using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  public float health = 100f;


    public void TakePlayerDamage(float amount) //Arguement for amount taken to hit.
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }   

    void Die()
    {
        Destroy(gameObject); // Destroys the game ibject
    }
  
}


