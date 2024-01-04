using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Fething Unitys Input System Libary in order to recieve and send  data send data to the Input System.

public class PlayerMovement : MonoBehaviour
{
    private Vector2 Movement; // It will get my Vector2 Input Actions
    private Rigidbody2D rb; //It will get my Rigidbody2D from my Character that we need in order to physically move the character
    private Animator myAnimator; // We need this in order to update our animations with our animator
    public float speed; // A public float that should determin our 



    private void Awake() //Should run as soon as the Program has started
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void OnMovement(InputValue value) //Should run when the program detects input from the user that is mapped inside our Input System hence why we wanted to fetch the Input System Libary. 
    {
        Movement = value.Get<Vector2>(); //The Vector2 data from our Input System gets stored inside our movement variable.

        if (Movement.x != 0 || Movement.y != 0) // The statement tells us if our Inputs (Vector2) X and Y axis dont have 0 as a value AKA It is moving
        {
            myAnimator.SetBool("IsWalking?", true);  // It should set our walking boolean inside our animator to be true.
        }
        else // This should run if our Inputs (Vector2) X and Y axis have 0 as a value AKA It is NOT moving
        {
            myAnimator.SetBool("IsWalking?", false); // It should set our walking boolean inside our animator to be false.
        }
    }

    private void FixedUpdate() //This is an Update method based on what we have assigned the FPS in our Editor
    {
        // Sets the Rigidbody's velocity to be the movement direction (Vector 2 X & Y-axis) multiplied by the speed variable.
        rb.velocity = Movement * speed;


    }


}



