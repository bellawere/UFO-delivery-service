using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackDemands : MonoBehaviour
{
    //Must not collide
    public bool fragile = false;

    //Temperature
    public float maxTemp = 20f;
    public float minTemp = -20f;

    //Turbulence
    public float maxTurb = 20f;
    public float minTurb = -20f;

    public bool rotten = false; //Change when package has exceeded its demands. Missions fails if a rotten package is delivered or released.

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Delivery")
        {
            Debug.Log("Delivered");
            Instantiate(gameObject, new Vector3(0, 1, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

