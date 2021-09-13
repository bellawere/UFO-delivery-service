using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundDetector : MonoBehaviour

{
    Rigidbody attached;

    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        attached = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
