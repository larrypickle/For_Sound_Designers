using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
 {
//     public GameObject weaponHolder;
//     public GameObject weaponPickUp;

//     // private WeaponSwitch weaponSwitch;

    
//     void Start()
//     {
//         // weaponSwitch = weaponHolder.GetComponent<WeaponSwitch>();
//         // weaponPickUp.GetComponent<Shooting>().enabled = false;
       
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//    void OnTriggerEnter(Collider col)
//     {
//         if(col.tag == "Player")
//         {
//             weaponPickUp.transform.parent = weaponHolder.transform;
//             weaponPickUp.transform.position = weaponHolder.transform.GetChild(0).position;
//             weaponPickUp.transform.rotation = weaponHolder.transform.GetChild(0).rotation;
//             weaponSwitch.SelectWeapon();
//             // weaponPickUp.GetComponent<Shooting>().enabled = true;
//             Destroy(gameObject);
//         }
//     }
}
