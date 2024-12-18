using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController playerCharacterController;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float initialSpeed = 10.0f;
    private float playerSpeed = 10.0f;
    public float cameraSensitivity = 5.0f;
    private float gravityValue = -9.81f;
    private Vector3 movementVector = Vector3.zero;
    public Camera mainCamera;
    private float sprintCurrentAmount;
    public float sprintCapacity = 100;

    private float forward;
    private float backwards;
    private float toLeft;
    private float toRight;
    private float sprint;
    private bool sprinting = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCharacterController = gameObject.GetComponent<CharacterController>();
        sprintCurrentAmount = sprintCapacity;
        playerSpeed = initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = playerCharacterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        /*Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerCharacterController.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Makes the player jump
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        playerCharacterController.Move(playerVelocity * Time.deltaTime);*/
    }
    void FixedUpdate()
    {
        playerSprint();
        calculateVector();
        if(movementVector != Vector3.zero)
        {
            playerCharacterController.Move(movementVector);
        }
    }
    public Vector3 calculateVector()
    {
        movementVector = Vector3.zero;
        if(forward == 1)
            movementVector += moveForward();
        if(backwards == 1)
            movementVector += moveBack();
        if(toLeft == 1)
            movementVector += moveLeft();
        if(toRight == 1)
            movementVector += moveRight();
        return movementVector;
    }

    public void forwardButton(InputAction.CallbackContext ctx)
    {
        forward = ctx.ReadValue<float>();
    }
    public void backwardsButton(InputAction.CallbackContext ctx)
    {
        backwards = ctx.ReadValue<float>();
    }
    public void toLeftButton(InputAction.CallbackContext ctx)
    {
        toLeft = ctx.ReadValue<float>();
    }
    public void toRightButton(InputAction.CallbackContext ctx)
    {
        toRight = ctx.ReadValue<float>();
    }
    public void sprintButton(InputAction.CallbackContext ctx)
    {
        sprint = ctx.ReadValue<float>();
        Debug.Log(sprint + "sprint");
    }

    public Vector3 moveForward()
    {
        Vector3 forwardVec = gameObject.transform.forward;
        forwardVec.y = 0;
        return forwardVec * playerSpeed * forward * (float)0.01;
    }

    public Vector3 moveBack()
    {
        Vector3 backwardVec = -gameObject.transform.forward;
        backwardVec.y = 0;
        return backwardVec * playerSpeed * backwards * (float)0.01;
    }

    public Vector3 moveLeft()
    {
        Vector3 left = -gameObject.transform.right;
        left.y = 0;
        return left * playerSpeed * toLeft * (float)0.01;
    }

    public Vector3 moveRight()
    {
        Vector3 right = gameObject.transform.right;
        right.y = 0;
        return right * playerSpeed * toRight * (float)0.01;
    }

    private void playerSprint()
    {
        if(sprint == 0)
        {
            sprinting = false;
            Debug.Log(sprintCurrentAmount + "huh 2");
        }
        else if(sprint == 1 && sprintCurrentAmount == 0)
        {
            Debug.Log("huh 3");
            sprinting = false;
        }
        else if(sprint == 1 && sprintCapacity == sprintCurrentAmount)
        {
            Debug.Log("huh 4");
            sprinting = true;  
        }     
        changePlayerSpeed();    
    }

    private void changePlayerSpeed()
    {
        if(sprinting && sprintCapacity == sprintCurrentAmount)
            playerSpeed += playerSpeed;
        else if(sprinting && sprintCurrentAmount == 0)
        {
            Debug.Log("huh 1");
            playerSpeed = initialSpeed;
            sprinting = false;
        }
        if(sprinting)
        {
            Debug.Log(sprintCurrentAmount + "not sprinting adding sprintCurrent");
            sprintCurrentAmount--;
        }
        else if(sprintCapacity > sprintCurrentAmount)
            sprintCurrentAmount += 0.5f;
        else if(sprintCapacity < sprintCurrentAmount)
            sprintCurrentAmount = sprintCapacity;
        if(!sprinting)
            playerSpeed = initialSpeed;
    }


    public void rotateCharacter(InputAction.CallbackContext ctx)
    {
        Mathf.Clamp(ctx.ReadValue<Vector2>().y/cameraSensitivity, -90, 90);
        Vector3 rotation = new Vector3(0, ctx.ReadValue<Vector2>().x/cameraSensitivity, 0);
        Vector3 cameraRotation = new Vector3(-Mathf.Clamp(ctx.ReadValue<Vector2>().y/cameraSensitivity, -90, 90), ctx.ReadValue<Vector2>().x/cameraSensitivity , 0);
        gameObject.transform.rotation = Quaternion.Euler(rotation);
        mainCamera.transform.rotation = Quaternion.Euler(cameraRotation);
    }
}
