using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float speed;
    public float suckForce = 100;
    public float magnetOffset = 0.5f;
    public float expandSuckIncrement = 1f;
    [HideInInspector]
    public List<Rigidbody> caughtRigidbodies = new List<Rigidbody>();
    private SphereCollider col;
    public float maxRadius = 5f;
    private Rigidbody rb;
    public Shoot shoot;
    public float startingRadius = 2f;
    // Start is called before the first frame update
    [HideInInspector]
    public bool reversed;
    public Transform player;
    public GameObject indicator;
    private GameObject ind;

    private void Start()
    {
        reversed = false;
        rb = gameObject.GetComponent<Rigidbody>();
        col = gameObject.GetComponent<SphereCollider>();
        col.radius = startingRadius;
        ind = (GameObject)Instantiate(indicator, transform.position, transform.rotation);
    }

    void Update()
    {
        ind.transform.localScale = new Vector3(col.radius * 2, col.radius * 2, col.radius * 2);
        //Debug.Log("ind transform: " + ind.transform.localScale);
        ind.transform.position = gameObject.transform.position;
    }
    void FixedUpdate()
    {
        //rb.AddForce(transform.forward * speed * Time.deltaTime);
        if (reversed)
        {
            transform.position += transform.forward * -1 * speed * Time.deltaTime;
        }
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        for (int i = 0; i < caughtRigidbodies.Count; i++)
        {
            caughtRigidbodies[i].velocity = (transform.position - (caughtRigidbodies[i].transform.position 
            + caughtRigidbodies[i].centerOfMass) + new Vector3(magnetOffset,magnetOffset,magnetOffset)) * suckForce * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>() && other.CompareTag("MovableGround"))
        {
            //Debug.Log("Blackhole collision");
            Rigidbody r = other.GetComponent<Rigidbody>();
            if (!caughtRigidbodies.Contains(r))
            {
                caughtRigidbodies.Add(r);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Rigidbody r = other.GetComponent<Rigidbody>();

            if (caughtRigidbodies.Contains(r))
            {
                //Remove Rigidbody
                caughtRigidbodies.Remove(r);
            }
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Hazard") || collision.gameObject.CompareTag("Ground"))
        {
            shoot.shot = false;
            shoot.leftClickBar.transform.localScale = Vector3.zero;
            shoot.rightClickBar.transform.localScale = Vector3.zero;
            Explode(0);
        }
    }*/

    public void Explode(float chargeTime)
    {
        //Debug.Log("Exploded");
        for (int i = 0; i < caughtRigidbodies.Count; i++)
        {
            //Debug.Log("actually Exploded");
            /*caughtRigidbodies[i].velocity = -1 * (transform.position - (caughtRigidbodies[i].transform.position
            + caughtRigidbodies[i].centerOfMass)) * suckForce * Time.deltaTime;*/

            caughtRigidbodies[i].AddForceAtPosition((caughtRigidbodies[i].position - transform.position).normalized * (suckForce * chargeTime), transform.position);
            caughtRigidbodies.Remove(caughtRigidbodies[i]);

            /*caughtRigidbodies[i].AddExplosionForce(100, -1 * (transform.position - (caughtRigidbodies[i].transform.position
            + caughtRigidbodies[i].centerOfMass)), 10);*/

        }
    }

    public void ExpandSuck()
    {
        
        if (col.radius <= maxRadius)
        {
            col.radius += expandSuckIncrement;
        }
        //Debug.Log("col.radius: " + col.radius);
    }
    
    public void PullBack()
    {
        transform.LookAt(player);
    }
    public void ReverseDirection()
    {
        StartCoroutine(Delay(0.1f));
    }
    
    public void Destroy()
    {
        Destroy(ind);
        Destroy(gameObject);
        
    }
    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        reversed = true;
    }

}
