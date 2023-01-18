using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    Rigidbody rb;
    Vector3 pushForce = new Vector3(0,0,0);
    float moveInputX, moveInputZ, moveInputY;
    public int Speed=0; //This public value can be accessible from the editor

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Component of type Rigidbody in rb
    }

    void Update() 
    {
        moveInputX = Input.GetAxis("Horizontal");
        moveInputZ = Input.GetAxis("Vertical");
        moveInputY = Input.GetAxis("Jump");

        pushForce.x = moveInputX;
        pushForce.z = moveInputZ;
        pushForce.y = moveInputY*10;

        //Debug.Log(pushForce);

    }

    private void FixedUpdate() 
    {
        //If related to physics it should be here, instead of update()
        //It is less rapid than in update() so we multiply vector by value of Speed
        //Multiply the speed with the delta time to have a smooth movement 
        //(every second the object moves a specific distance regardless of the carrets 
        //which are related to the speed of the computer running the program)
         rb.AddForce(pushForce * Speed * Time.deltaTime); //Apply a force to the object

    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag=="Pickups") 
        {
            other.gameObject.SetActive(false);
        }
        if (other.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}
