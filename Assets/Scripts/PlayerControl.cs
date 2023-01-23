using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{

    Rigidbody rb;
    Vector3 pushForce = new Vector3(0,0,0);
    float moveInputX, moveInputZ, moveInputY;
    public int Speed=0; //This public value can be accessible from the editor

    public TextMeshProUGUI scoreText;
    private int score;
    private int cubePoints = 5; //5 points per cube

    public GameObject winText;
    public GameObject gameOver;
    private int cubeNumber=12;

    public Transform Level2Teleport;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Component of type Rigidbody in rb

        score = 0;
        SetScoreText();

        winText.SetActive(false); //Hide winText
        gameOver.SetActive(false); //Hide gameOver

        //cubeNumber = GameObject.FindGameObjectsWithTag("Pickups").Length;
        cubeNumber = 12;
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
            score += cubePoints; //Increase score when touching a cube
            SetScoreText();
        }
        if (other.tag == "Enemy")
        {
            gameObject.SetActive(false);
            gameOver.SetActive(true);
            Time.timeScale = 0; //Freeze game when we lose - normal game velocity is 1.

        }
        if(other.tag == "Teleport")
        {
            transform.position = Level2Teleport.position;
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score " + score; //UI element TextMeshPro

        if(score >= cubeNumber * cubePoints) //we have 12 cubes
        {
            winText.SetActive(true);
            Time.timeScale = 0; //Freeze game when we win - normal game velocity is 1.
        }
    }
}
