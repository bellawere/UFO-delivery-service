using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Animator))]
public class Controles : MonoBehaviour
{
    Rigidbody player;
    Animator anim;

    float h;
    float v;
    float j;
    bool grounded;
    bool walk;
    bool sprint;

    public float speed;
    public float jump = 3.0f;
    public GameObject ground;
 
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        player.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update()
    {
        h = CrossPlatformInputManager.GetAxis("Horizontal");
        v = CrossPlatformInputManager.GetAxis("Vertical");
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            j = jump;
        }
	    walk = Input.GetKey(KeyCode.LeftShift);
        sprint = Input.GetKey(KeyCode.LeftControl);
    }

    void Mover(Vector3 movement)
    {
        anim.SetFloat("Forward", player.transform.InverseTransformDirection(player.velocity).z);

        var localspeed = speed;

        if (walk)
        {
            localspeed = (speed * 0.5f);
        }
        else if (sprint)
        {
            localspeed = (speed * 2);
        }

        //player.MovePosition(transform.position + (movement * speed * Time.deltaTime));
        player.AddRelativeForce(new Vector3(0, movement.y, movement.z) * localspeed);
        if(movement.y > 0)
        {
            j = 0f;
        }
        player.AddRelativeTorque(transform.up * movement.x * speed);
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        Mover(new Vector3(h, j, v));
    }
}
