/***Jorge Castillo 2023.09.26
Script for basic Third person and character controls based on RigidBodies***/
//Libraries that we're using
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{

    //Variable Declarations

    //Input Variables
    private Vector2 move_input;

    //Camera Variables

    public Transform camera;

    //Player variable
    public Rigidbody rigidbody;
    public Transform player;
    public Transform player_model;
    public Transform orientation;
    public float move_force; //forece appliede to plater
    public float rotation_speed; //how fast we rotate
    public float jumpforce = 500.0f;
    private Vector3 direction;

    //Ray cast variable
    private float ray_lenght = 500;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible=false;

    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayerModel();
        Debug.DrawRay(transform.position, Vector3.down * ray_lenght, Color.blue);
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    public void GetMovementInput(InputAction.CallbackContext context)
    {
        move_input = context.ReadValue<Vector2>();
        Debug.Log(move_input);
    }
    public void GetJumpInput(InputAction.CallbackContext context)
    {
      if(context.phase == InputActionPhase.Started)
        {
            Jump();
        }
    }
    public void RotatePlayerModel()
    {
        //What direction to face
        var cam_position = new Vector3(camera.position.x, camera.position.y, camera.position.z);
        Vector3 view_direction = player.position - cam_position;

        orientation.forward = view_direction;

        //Set the direction
        direction = orientation.right * move_input.x + orientation.forward * move_input.y;
        direction = direction.normalized;

        //keynoard Input

        if (move_input != Vector2.zero)
        {
            //this creates a new rotation that we want the plater_model to look at
            Quaternion new_rotation = Quaternion.LookRotation(direction, Vector3.up);

            //Calculate rotation, now we want the player+model to move towards the rotation
            player_model.rotation = Quaternion.Slerp(player_model.rotation,new_rotation, rotation_speed * Time.deltaTime);
       }

    }
    public void MovePlayer()
    {

        rigidbody.AddForce(direction * move_force, ForceMode.Force);
    }
    public void Jump()
    {
        if (IsOnGround())
        {
            rigidbody.AddForce(Vector3.up * jumpforce);
        }
    }

    bool IsOnGround()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(ray, ray_lenght);
    }

}
