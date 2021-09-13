using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipControl : MonoBehaviour
{
    Rigidbody ship;
    public KeyCode thrust;
    public KeyCode brake;
    public KeyCode turnR;
    public KeyCode turnL;
    public KeyCode rise;
    public KeyCode rollR;
    public KeyCode rollL;
    public float velocity;

    float altitude;
    float speed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        ship =  GetComponent<Rigidbody>();
        Vector3 initpos = ship.transform.position;
        altitude = initpos.y;
    }

    // Update is called once per frame
    void Update()
    { 
        if(Input.GetKey(thrust)){
            speed += velocity;
        }

        if(Input.GetKey(brake)){
            speed -= velocity;
        }

        if(Input.GetKey(turnL)){
            Vector3 euler = new Vector3(0, -100, 0);
            Quaternion deltaRotation = Quaternion.Euler(euler * Time.deltaTime);
            ship.MoveRotation(ship.rotation * deltaRotation);
            Vector3 eulerRoll = new Vector3(0, 0, 10);
            Quaternion deltaRotationRoll = Quaternion.Euler(eulerRoll * Time.deltaTime);
            ship.MoveRotation(ship.rotation * deltaRotationRoll);
        }

        
        if(Input.GetKey(turnR)){
            Vector3 euler = new Vector3(0, 100, 0);
            Quaternion deltaRotation = Quaternion.Euler(euler * Time.deltaTime);
            ship.MoveRotation(ship.rotation * deltaRotation);
            Vector3 eulerRoll = new Vector3(0, 0, -10);
            Quaternion deltaRotationRoll = Quaternion.Euler(eulerRoll * Time.deltaTime);
            ship.MoveRotation(ship.rotation * deltaRotationRoll);
        }
        
        if(Input.GetKey(rollL)){
            Vector3 eulerRoll = new Vector3(0, 0, 100);
            Quaternion deltaRotationRoll = Quaternion.Euler(eulerRoll * Time.deltaTime);
            ship.MoveRotation(ship.rotation * deltaRotationRoll);
        }

        
        if(Input.GetKey(rollR)){
            Vector3 eulerRoll = new Vector3(0, 0, -100);
            Quaternion deltaRotationRoll = Quaternion.Euler(eulerRoll * Time.deltaTime);
            ship.MoveRotation(ship.rotation * deltaRotationRoll);
        }
    }

    void FixedUpdate()
    {
        if(ship.velocity.x > 0){
            Vector3 accel = new Vector3(-2.0f, 0.0f, 0.0f);
            ship.AddForce(accel);
        }
        
        if(ship.velocity.y > 0 || ship.transform.position.y > altitude){
            Vector3 accel = new Vector3(0.0f, -2.0f, 0.0f);
            ship.AddRelativeForce(accel);
        }

        if(ship.transform.position.y < altitude){
            Vector3 accel = new Vector3(0.0f, 5.0f, 0.0f);
            ship.AddRelativeForce(accel);
        }
        
        if(speed > 0){
            speed -= velocity;
        }

//

        transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);

        if(Input.GetKey(rise)){
            Vector3 accel = new Vector3(0.0f, 5.0f, 0.0f);
            ship.AddRelativeForce(accel, ForceMode.Acceleration);
        }
    }
}
