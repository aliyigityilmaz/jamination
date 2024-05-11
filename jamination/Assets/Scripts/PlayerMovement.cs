using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool CanMove { get; private set; } = true;

    private bool CanInteract = true;
    private bool useFootStepSounds = true;

    [Header("Movement Parameters")]
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float gravity = 30.0f;

    [Header("Camera Parameters")]
    [SerializeField, Range(1, 10)] private float lookSpeedX = 2.0f;
    [SerializeField, Range(1, 10)] private float lookSpeedY = 2.0f;
    [SerializeField, Range(1, 180)] private float upperLookLimit = 80.0f;
    [SerializeField, Range(1, 180)] private float lowerLookLimit = 80.0f;

    [Header("Head Bobbing Parameters")]
    [SerializeField] private float walkBobSpeed = 14f;
    [SerializeField] private float walkBobAmount = 0.05f;
    private float defaultPosY = 0;
    private float timer;

    private Camera playerCamera;
    private CharacterController controller;

    private Vector3 moveDirection;
    private Vector2 currentInput;

    private float rotationX = 0;

    [Header("Interaction")]
    [SerializeField] private Vector3 interactionRayPoint = default;
    [SerializeField] private LayerMask interactableLayer = default;
    [SerializeField] private float interactionRange = default;
    private Interactable currentInteractable;

    [Header("Footstep Sounds")]
    [SerializeField] private float baseStepSpeed = 0.5f;
    [SerializeField] private AudioSource footStepAudioSource =default;
    [SerializeField] private AudioClip[] woodClips = default;
    private float footStepTimer = 0;

    private void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        controller = GetComponent<CharacterController>();
        defaultPosY = playerCamera.transform.localPosition.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (CanMove)
        {
            GetInput();
            Move();
            Look();

            if (CanInteract)
            {
                HandleInteractionCheck();
                HandleInteractionInput();
            }
            if (useFootStepSounds)
            {
                HandleFoodSteps();
            }
        }
    }

    private void HandleFoodSteps()
    {
        if (!controller.isGrounded) return;
        if (currentInput == Vector2.zero) return;

        footStepTimer -= Time.deltaTime;

        if (footStepTimer <= 0)
        {
            if(Physics.Raycast(gameObject.transform.position, Vector3.down, out RaycastHit hit, 3))
            {
                if(hit.collider.tag == "Wood")
                {
                    
                    footStepAudioSource.PlayOneShot(woodClips[UnityEngine.Random.Range(0, woodClips.Length -1)]);
                    footStepTimer = baseStepSpeed;
                    Debug.Log("Walking on wood");
                     
                }
            }
            footStepTimer = baseStepSpeed;
        }
    }


    private void HandleInteractionCheck()
    {
        if(Physics.Raycast(playerCamera.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactionRange))
        {
            if(hit.collider.gameObject.layer == 9 && (currentInteractable == null || hit.collider.gameObject.GetInstanceID() != currentInteractable.GetInstanceID()))
            {
                hit.collider.TryGetComponent(out currentInteractable);

                if(currentInteractable != null)
                {
                    currentInteractable.OnFocus();
                }
            }
        }
        else if(currentInteractable != null)
        {
            currentInteractable.OnLoseFocus();
            currentInteractable = null;
        }
    }

    private void HandleInteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null && Physics.Raycast(playerCamera.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactionRange, interactableLayer))
        {
            currentInteractable.OnInteract();
        }
        else if (Input.GetKey(KeyCode.E) && currentInteractable != null && Physics.Raycast(playerCamera.ViewportPointToRay(interactionRayPoint), out RaycastHit hit1, interactionRange, interactableLayer))
        {
            currentInteractable.OnHoldInteract();
        }
    }

    private void Look()
    {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
    }

    private void Move()
    {
        if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        controller.Move(moveDirection * Time.deltaTime);
        HandleHeadBob();
    }

    private void GetInput()
    {
        currentInput = new Vector2(walkSpeed * Input.GetAxis("Vertical"), walkSpeed * Input.GetAxis("Horizontal"));
        float moveDirectionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        moveDirection.y = moveDirectionY;
    }

    private void HandleHeadBob()
    {
        if (controller.isGrounded)
        {
            if (Mathf.Abs(moveDirection.x) > 0.1f || Mathf.Abs(moveDirection.z) > 0.1f)
            {
                timer += Time.deltaTime * walkBobSpeed;
                playerCamera.transform.localPosition = new Vector3(playerCamera.transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * walkBobAmount, playerCamera.transform.localPosition.z);
            }
        }
    }

    
}
