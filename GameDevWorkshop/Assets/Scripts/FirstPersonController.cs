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
        characterController = GetComponent<CharacterController>();

        //Hide mouse coursor at start

        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        grounded = characterController.isGrounded;
        MovePlayer();
        Look();

    }
    public void MovePlayer()
    {
        //Direction Move
        Vector3 moveVec = transform.right * moveInput.x + transform.forward * moveInput.y;
        //Move character controller
        characterController.Move(moveVec * Time.deltaTime);
        //Add Graviti
        playerVelocity.y += gravity * Time.deltaTime;
        if (grounded && playerVelocity.y < 0)
        {

            playerVelocity.y = -2.5f;    

        }
        characterController.Move(playerVelocity * Time.deltaTime);

    }

    public void Look()
    {
        float xAmoutn = mouseMovement.x * sensitivity * Time.deltaTime;
        float yAmoutn = mouseMovement.y * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseMovement * sensitivity * Time.deltaTime);

        camXRotation -= xAmoutn;
        camXRotation = Mathf.Clamp(camXRotation, -90f, 90f);
    }

    public void onMove(InputAction.CallbackContext contex)
    {

        moveInput = contex.ReadValue<Vector2>();
        Debug.Log("Move Input value: " + moveInput.ToString());

    }
    public void onLook(InputAction.CallbackContext contex)
    {
        mouseMovement = contex.ReadValue<Vector2>();
        Debug.Log("Mouse Movemente: " + mouseMovement.ToString());
    }
    public void onJump(InputAction.CallbackContext contex)
    {
        Jump();
        Debug.Log("Hi dude! im Jumping");
    }

    public void Jump()
    {
        if (grounded)
        {
            playerVelocity.y = jumpForce;
            
        }
    }
}

