using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipControlAdv : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

    float h;
    float v;
    bool beam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        beam = Input.GetKey(KeyCode.LeftControl);

        if (beam)
        {
            Capturar();
        }
    }

    private void FixedUpdate()
    {
        float hspeed = h * speed * Time.deltaTime;
        float vspeed = v * speed * Time.deltaTime;

        Mover(new Vector2(hspeed, vspeed));
    }

    void Mover(Vector2 movement)
    {
        rb.AddRelativeForce(new Vector3(movement.x, 0, movement.y));
    }

    void Capturar()
    {
        RaycastHit hit;

        if(Physics.Raycast(rb.transform.position, -rb.transform.up, out hit))
        {
            Debug.DrawRay(rb.transform.position, -rb.transform.up * hit.distance, Color.green);

            if (hit.collider.gameObject.tag == "Grabbable")
            {
                Rigidbody captured = hit.rigidbody;
                if (rb.transform.position.y - captured.position.y > 2)
                {
                    captured.AddForce(new Vector3(0,10f,0));
                }
                captured.MovePosition(new Vector3(rb.transform.position.x, captured.position.y, rb.transform.position.z));
            }
        }
    }

}
