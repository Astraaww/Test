using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private CharacterController characterController;
    [SerializeField] private Camera playerCamera;

    public float runAcceleration = 0.25f;
    public float runSpeed = 4f;

    private PlayerLocomotionInput playerLocomotionInput;

    // Start is called before the first frame update
    void Awake()
    {
        playerLocomotionInput =  GetComponent <PlayerLocomotionInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraForwardXZ = new Vector3(playerCamera.transform.forward.x, 0f, playerCamera.transform.forward.z).normalized;
        Vector3 cameraRightXZ = new Vector3(playerCamera.transform.right.x, 0f, playerCamera.transform.right.z).normalized;
        Vector3 movementDirection = cameraRightXZ * playerLocomotionInput.MovementInput.x + cameraForwardXZ * playerLocomotionInput.MovementInput.y;

        Vector3 movementDelta = movementDirection * runAcceleration * Time.deltaTime;
        Vector3 newVelocity = characterController.velocity + movementDelta;

        characterController.Move(newVelocity * Time.deltaTime);
    }
}
