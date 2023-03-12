using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController controller;
    public Vector3 playerVelocity;
    public float speed = 5f;
    private int laneDistance=3;
    private int currPath=1;
    private float gravity = -9.8f;
    private float jumpHeight = 3f;
    private bool rollStart;
    void Start()
    {
        
  
        playerVelocity = Vector3.zero;
        
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerVelocity.z = speed;

        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2;
        }
        else
        {
            playerVelocity.y += gravity * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || SwipeManager.swipeUp)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || SwipeManager.swipeDown)
        {
            Roll();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || SwipeManager.swipeRight)
        {
            
            currPath++;
            if (currPath == 3) currPath = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)|| SwipeManager.swipeLeft)
        {
            
            currPath--;
            if (currPath == -1) currPath = 0;
        }
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (currPath == 0)
        {
        
            targetPosition += Vector3.left * laneDistance;
        }
        else if (currPath == 2)
        {
           
            targetPosition += Vector3.right * laneDistance;
        }
       



        transform.position = targetPosition;
        controller.center = controller.center;
        
        
    }

    private void FixedUpdate()
    {
        
        controller.Move(playerVelocity * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        
    }

    private void Jump()
    {
        if(controller.isGrounded)
        playerVelocity.y = Mathf.Sqrt(jumpHeight*-gravity);
    }

    private void Roll()
    {
        controller.center = new Vector3(0,-0.5f,0);
        controller.height = 1;
        GetComponentInChildren<Animator>().SetBool("rollStart", true);
        Invoke("RollStop", 1.5f);
        

    }

    private void RollStop()
    {
        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        GetComponentInChildren<Animator>().SetBool("rollStart", false);
    }
}
