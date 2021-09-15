using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //Variables
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    //Connection to animator
    //public Animator animator;

    //Directional variables
    enum Direction
    {
        Idle,
        Up,
        Down,
        Left,
        Right
    }
    private Direction currentDirection;
    private Direction previousDirection;


    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?

        //Feed moveDirection with input.
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        //Multiply it by speed.
        moveDirection *= speed;
        //Jumping
        if (Input.GetButton("Jump"))
            moveDirection.y = jumpSpeed;

        
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);


        //AnimationManagement();
    }

    private void AnimationManagement()
    {
        // Detect inputs to determine travel direction   
        if ((Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)))
        {
            //Debug.Log("Idling.");
            currentDirection = previousDirection;
        }

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            //Debug.Log("Going Up.");
            currentDirection = Direction.Up;
            previousDirection = currentDirection;
        }


        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            //Debug.Log("Going Down.");
            currentDirection = Direction.Down;
            previousDirection = currentDirection;
        }


        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            //Debug.Log("Goign Left.");
            currentDirection = Direction.Left;
            previousDirection = currentDirection;
        }


        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Going Right.");
            currentDirection = Direction.Right;
            previousDirection = currentDirection;
        }

        
        if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            //Debug.Log("Idling.");
            currentDirection = Direction.Idle;
        }



        /*
        // Manage animations
        if(currentDirection == Direction.Idle)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }
        else if(currentDirection == Direction.Up)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Up", true);
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }
        else if(currentDirection == Direction.Down)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }
        else if (currentDirection == Direction.Left)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
        }
        else if (currentDirection == Direction.Right)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", true);
        }
        */

    }
}