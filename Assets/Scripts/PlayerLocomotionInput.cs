using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLocomotionInput : MonoBehaviour, PlayerControls.IPlayerLocomotionMapActions
{

    public PlayerControls playerControls;
    public Vector2 MovementInput;

    private void Awake()
    {
        // Instancie le sch�ma de contr�le
        playerControls = new PlayerControls();
        // Configure les callbacks pour la carte d'actions PlayerLocomotionMap
        playerControls.PlayerLocomotionMap.SetCallbacks(this);
    }

    private void OnEnable()
    {
        // Active les contr�les
        playerControls.PlayerLocomotionMap.Enable();
    }

    private void OnDisable()
    {
        // D�sactive les contr�les
        playerControls.PlayerLocomotionMap.Disable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        // R�cup�re l'entr�e de mouvement
        MovementInput = context.ReadValue<Vector2>();
        Debug.Log($"Movement Input: {MovementInput}");
    }
}
