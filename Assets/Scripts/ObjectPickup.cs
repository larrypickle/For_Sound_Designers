using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectPickup : MonoBehaviour
{
    public TextMeshProUGUI winText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winText.SetText("YOU WIN");
            Destroy(gameObject);
        }
    }
}
