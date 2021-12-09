using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public Transform playerCamera = null;
    public Rigidbody rb;
    public CharacterController cc;
    public Animator springAnimator;
    public float mouseSensitivity = 3.5f;
    public float walkSpeed = 24.0f;
    public float gravity = -20.0f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;

    public bool lockCursor = true;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    CharacterController controller = null;

    private float timeLeftGrounded = 0;
    public float jumpHeight = 12;

    public Vector3 respawnPosition1;
    GameObject respawnPoint;
    private Vector3 rotation = Vector3.zero;
    // private bool isCrouched = false;
    // private Vector3 crounchScale;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    private float delta;
    CameraHandler cameraHandler;

    /*public bool isGrounded
    {
        get
        {
            return controller.isGrounded || timeLeftGrounded > 0;
        }
    }*/




    void Start()
    {
        Time.timeScale = 1;
        controller = GetComponent<CharacterController>();
        cameraHandler = CameraHandler.singleton;
        //locks cursor to the middle of the screen and remove the icon
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        PlayerPrefs.GetString("spawnLoc");

        respawnPoint = GameObject.Find("RespawnPoint1");
        respawnPosition1 = respawnPoint.transform.position;

    }

    void Update()
    {

        if (Time.timeScale == 1)
        {
            delta = Time.fixedDeltaTime;
            if (cameraHandler != null)
            {
                cameraHandler.FollowTarget(delta);
                //cameraHandler.HandleCameraRotation(delta);
            }
            UpdateMouseLook();


            if (transform.position.y <= -50)
            {
                //print("work fcker");
                //print("heres yer position " + transform.position.ToString());
                print("respawn here " + respawnPosition1);
                transform.position = respawnPosition1;



            }
            else
            {
                UpdateMovement();
            }
        }

    }

    //Camera movements
    void UpdateMouseLook()
    {
        //print("Helloo");
        if (DialogueSystem.inConversation) return;
        Vector2 targetmouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetmouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -45.0f, 45.0f);
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);

    }


    //Character Movement
    void UpdateMovement()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsMenu.SetActive(false);
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            Cursor.visible = !Cursor.visible;
        }*/
        if (DialogueSystem.inConversation)
        {
            return;
        }
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            springAnimator.SetBool("isMoving", false);
            walkSpeed = 0;
        }
        else
        {
            springAnimator.SetBool("isMoving", true);
            if (Input.GetKeyDown(KeyCode.LeftShift) && controller.isGrounded)
            {

                walkSpeed = 30.0f;

            }
            if (!Input.GetKey(KeyCode.LeftShift) && controller.isGrounded)
            {

                walkSpeed = 24.0f;

            }
        }
        //bool isJumpHeld = Input.GetButton("Jump");
        //bool onJumpPress = Input.GetButtonDown("Jump");

        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        //adds falling to the character
        if (controller.isGrounded)
        {
            velocityY = 0.0f;
            timeLeftGrounded = .2f;
            if (Input.GetButton("Jump"))
            {
                velocityY = jumpHeight;
                //timeLeftGrounded = 0;
                springAnimator.SetBool("isJumping", true);
            }
            else
            {
                springAnimator.SetBool("isJumping", false);
            }
        }
        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);


    }


}
