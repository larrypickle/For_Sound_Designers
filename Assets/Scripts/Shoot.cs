using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    //[HideInInspector]
    //public BlackHole blackHole;
    private GameObject bh;
    [HideInInspector]
    public bool shot;
    private float shotTimer = 0;
    public float shotTimerMax = 5f;
    // Start is called before the first frame update
    
    public Transform firePoint;
    private bool timeDelayed;
    public GameObject blackHoleLoaded;
    public float minDistance = 15f;

    //public Animator animShoot;
    void Start()
    {
       
        shot = false;
        timeDelayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(shot == false)
            {
                //animShoot.SetBool("Activate", true);
                RaycastHit hit;
                Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
                Debug.Log("hit distance: " + hit.distance);
                bh = (GameObject)Instantiate(projectile, firePoint.transform.position, Camera.main.transform.rotation);
                if (hit.distance > minDistance)
                {
                    bh.transform.LookAt(hit.point);
                }
            }
            shot = true;
            BlackHole blackHole = bh.GetComponent<BlackHole>();
            if (!Input.GetMouseButtonUp(0))
            {
                blackHole.ExpandSuck();
                blackHoleLoaded.SetActive(false);
                
            }
            
            //expanding ui bar
            /*Vector3 temp = leftClickBar.gameObject.transform.localScale;
            temp = new Vector2((blackHole.gameObject.GetComponent<SphereCollider>().radius - blackHole.startingRadius) / (blackHole.maxRadius - blackHole.startingRadius), 1);
            Debug.Log("bar size: " + temp.x);
            leftClickBar.transform.localScale = temp;*/
            //Debug.Log("Expand suck");
            //bh.GetComponent<BlackHole>().ExpandSuck(magnetTimer);
            
        }
        

        if (Input.GetMouseButton(1) && shot == true)
        {
            //animShoot.SetBool("Activate", false);
            //Debug.Log("Mouse input detected");
            /*Vector3 temp = rightClickBar.gameObject.transform.localScale;
            temp = new Vector2(shotTimer/shotTimerMax, 1);
            rightClickBar.transform.localScale = temp;
            if(shotTimer <= shotTimerMax)
            {
                shotTimer += Time.deltaTime;
            }*/
            BlackHole blackHole = bh.GetComponent<BlackHole>();
            if (!blackHole.reversed)
            {
                blackHole.ReverseDirection();
            }


        }
        if (Input.GetMouseButtonUp(1) && shot == true)
        {
            BlackHole blackHole = bh.GetComponent<BlackHole>();
            blackHole.Explode(0);
            blackHole.Destroy();
            shot = false;
            timeDelayed = false;
            blackHoleLoaded.SetActive(true);

            /*blackHole.Explode(shotTimer);
            shot = false;
            shotTimer = 0;
            rightClickBar.transform.localScale = Vector3.zero;
            leftClickBar.transform.localScale = Vector3.zero;*/


        }
    }
    

}
