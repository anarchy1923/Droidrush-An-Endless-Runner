using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject pickUpEffect;
    public float moveSpeed;    // we have made a public variable so that it can be easily accessed by any other variable or function. 

    bool movingLeft = true;   // in the beginning our car will move to the left, so we set it as true. 
    bool firstInput = true;     // when we have not started the game, then first input should be true.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted)    //only when the game has started we check the input.
        {
            Move();      // move function will be called again and again and again. 
            CheckInput();//keeps checking the input whether the player is tapping or not. 
        }

        if (transform.position.y <= -2)
        {
            GameManager.instance.GameOver();
        }
        
    }


    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;               //multiplying direction with the movescript so that we can tell that our object is moving with a 
                                                                                           //move speed in the forward direction. time.DeltaTime shows that we are moving the car every single second instead of every single frame. 
    }

    void CheckInput()   // to check if we are clicking or tapping on the screen.
    {
        // if first input then ignore
        if (firstInput)
        {
            firstInput = false; // we ARE not having the first input again. 
            return;             // WHEN WE TAP THE FIRST TIME, WE ARE GOING TO IGNORE ALL THESE THINGS. 
        }

        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();    //when we click our left mouse button or touch we call our changeDirection function. 
        }

    }

    void ChangeDirection()
    {
        if (movingLeft)
        {
            movingLeft = false;                                 //car is no more moving to the left. 
            transform.rotation = Quaternion.Euler(0, 90, 0);    // when we change the y rotation to 90 it moves to the right in the editor. 
        }
        else
        {
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);    //car starts moving to the left. 
        }
    }


    
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Diamond")
        {
            GameManager.instance.IncrementScore();

            Instantiate(pickUpEffect, other.transform.position, pickUpEffect.transform.rotation); // to get the position of the diamond

            other.gameObject.SetActive(false);
        }
    }
}
