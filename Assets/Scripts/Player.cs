using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private CharacterController characterController;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float mouseSensitivity = 30f;
    [SerializeField] private float gravityMultiplier = 30f;
    [SerializeField] private float jumpForce = 50f;
    [SerializeField] private float verticalLookRange = 80f;

    private Vector3 moveInput;
    private Vector2 lookDeltaInput;
    private Vector3 jumpVelocity;

    private InputAction interact;
    public bool interacting = false;

    //private float verticalVelocity = 0f;
    private float verticalRotation = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else         {
            Destroy(gameObject);
            return;
        }

        characterController = GetComponent<CharacterController>();
    }
    private void Start()
    {
        interact = InputSystem.actions["Interact"];
    }
    public void OnMove(InputValue inputValue)
    {
        var rawInput = inputValue.Get<Vector2>();
        moveInput = new(rawInput.x, 0f, rawInput.y);
    }

    public void OnLook(InputValue inputValue)
    {
        lookDeltaInput = inputValue.Get<Vector2>() * mouseSensitivity;
    }

    public void OnJump()
    {
        if (characterController.isGrounded)
        {
            jumpVelocity = (transform.forward + transform.up) * jumpForce;
            //verticalVelocity += jumpForce;
        }
    }

    private void Update()
    {
        if (interact.WasPressedThisFrame())
        {
            Debug.Log("Interacting");
            interacting = true;
        }else interacting = false;

        transform.Rotate(0f, lookDeltaInput.x * Time.deltaTime, 0f);
        if (!Mathf.Approximately(lookDeltaInput.y, 0f))
        {
            verticalRotation = Mathf.Clamp(verticalRotation - lookDeltaInput.y * Time.deltaTime, -verticalLookRange, verticalLookRange);
            Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        }
        
        var movement = (transform.forward * moveInput.z + transform.right * moveInput.x);
        if (characterController.isGrounded && jumpVelocity.y < 0f)
        {
            jumpVelocity = Vector3.down;
            //verticalVelocity = -1f;
        }
        else
        {
            //verticalVelocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
            jumpVelocity += Physics.gravity * gravityMultiplier * Time.deltaTime;
        }

        movement += jumpVelocity;
        //movement.y = verticalVelocity;

        characterController.Move(Time.deltaTime * movementSpeed * movement);
    }
}
