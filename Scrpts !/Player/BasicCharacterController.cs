using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharacterController : MonoBehaviour
{
    [Header("Player Control Options")]
    [SerializeField, Range(0,100)]
    float jumpHeight = 1;

    public float gravityMultiplier = 1;
    
    [SerializeField, Range(0,200), Space]
    float walkSpeed = 5f;

    [SerializeField, Range(0, 200)]
    float runSpeed = 7.5f;

    [SerializeField, Range(0.01f,50), Space]
    float lookSpeed = 3;

    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    CharacterController characterController;

    public AudioSource deathSound;

    private float speed;

    [SerializeField]
    private LayerMask groundMask;
    private float groundCheckDistance;
    private float rotationX = 0f;

    bool dead;

    bool IsGrounded => characterController.isGrounded;

    /// <summary>
    /// A rough position of where the player's face is. uses the camera as the face position
    /// </summary>
    public Vector3 FacePosition => playerCamera.transform.position + playerCamera.transform.forward;

    float yVelocity = 0;

    void Start()
    {
        CapsuleCollider collider = GetComponent<CapsuleCollider>();
        groundCheckDistance = collider.height / 2f + .1f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        speed = walkSpeed;
    }

    void Update()
    {

        if (Time.timeScale < 0.01f || dead) return;

        if(IsGrounded){

            if(Input.GetButtonDown("Jump")){
                Jump();
            }

            if(Input.GetKey(KeyCode.LeftShift)){
                speed = runSpeed;
            } else{
                speed = walkSpeed;
            }
        }else{
            // gravity
            yVelocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // moving the character controller
        Vector3 inputDirection = new Vector3(horizontal, 0, vertical).normalized;

        if(inputDirection != Vector3.zero){
            AudioManager.Instance.StartWalking();
        } else{
            AudioManager.Instance.StopWalking();
        }

        // get a smooth input intensity to give smoothing to start/stop
        float inputIntensity = Mathf.Max(Mathf.Abs(horizontal), Mathf.Abs(vertical));
        inputDirection = inputDirection * inputIntensity;
        Vector3 finalVelocty = transform.TransformDirection(inputDirection) * speed;
        finalVelocty.y = yVelocity;
        characterController.Move(finalVelocty * Time.deltaTime);       

        //left and right rot
        // I was wondering why mouse look was funky, it turns out that
        // against what you would expect, mouse look works better without taking delta time into account
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        
        //updown rot
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -90, 90);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0 , 0);
        
    }


    private void Jump(){
        
        float jumpSpeed = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y * gravityMultiplier);
        yVelocity = jumpSpeed;
    }
}

