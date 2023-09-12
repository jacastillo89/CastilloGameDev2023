/***Jorge Castillo 2023.09.12
Script for basic first person and character controls



***/

//Libraries that we're using
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour

{
    //Player Variables
    public float speed;
    public float gravity;
    public float jumpForce;
    
    //Movement and Looking 
    private CharacterController characterController;
    private Vector2 moveInput;
    private Vector3 playerVelocity;
    private bool grounded;
    private Vector2 mouseMovement;

    //Camera vairables
    public Camera cameraLive;
    public float sensitivity;
    private float camXRotation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onMove(InputAction.CallbackContext contex)
    {
        
    }
    public void onLook(InputAction.CallbackContext contex)
    {

    }
    public void onJump(InputAction.CallbackContext contex)
    {

    }
}

