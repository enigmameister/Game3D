using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMotor : MonoBehaviour
{
    public GameSounds GS;

    private CharacterController controller; 

    private Vector3 playerVelocity;     
    private bool isGrounded;          
    private bool lerpCrouch = false;        
    private bool crouching = false;     
    private bool walking = false;       
    public bool climbing = false;     

    public float crouchTimer = 0.2f;    
    public float speed = 8;                
    public float gravity = -9.8f;          
    public float jumpHeight = 1.5f;         


    void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }
    void Update()    
    {
        isGrounded = controller.isGrounded;     
 
        if (lerpCrouch)                     
        {
            crouchTimer += Time.deltaTime; 
            float p = crouchTimer / 1;      
            p *= p;                         
            if (crouching)                  
            {
                
                controller.height = Mathf.Lerp(controller.height, 1, p); 
                speed = 3f;                                             
            }
            else
                controller.height = Mathf.Lerp(controller.height, 2, p); 
                speed = 8f;
        if(p>1)                    
            {
                lerpCrouch = false;
                crouchTimer = 0f;
                
            }
        }
    }
    public void ProcessMove(Vector2 input) 
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        

        controller.Move(playerVelocity * Time.deltaTime);
    }
    public void Climbing()
                           
    {
        if (climbing)
        {

           
            if (Input.GetKey(KeyCode.W))
            {
                playerVelocity.y = 5f;
                
                controller.transform.localPosition += Time.deltaTime * Vector3.up;

            }
            if (Input.GetKey(KeyCode.S))
            {
                controller.transform.localPosition +=  Time.deltaTime * Vector3.down;
                playerVelocity.y = -5f;
               
            }
        }
     
    }

    public void Jump() 
    {
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            GS.PlayerJump();
        }
    }

    public void Crouch() 
    {
        crouching = !crouching; 
        crouchTimer = 0;     
        lerpCrouch = true;  
    }
    public void Walk()
    { 
        walking = !walking;
        if (walking) speed = 3;
        else speed = 8;   
    }
}
