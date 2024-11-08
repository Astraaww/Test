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
        // Instancie le schéma de contrôle
        playerControls = new PlayerControls();
        // Configure les callbacks pour la carte d'actions PlayerLocomotionMap
        playerControls.PlayerLocomotionMap.SetCallbacks(this);
    }

    private void OnEnable()
    {
        // Active les contrôles
        playerControls.PlayerLocomotionMap.Enable();
    }

    private void OnDisable()
    {
        // Désactive les contrôles
        playerControls.PlayerLocomotionMap.Disable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        // Récupère l'entrée de mouvement
        MovementInput = context.ReadValue<Vector2>();
        Debug.Log($"Movement Input: {MovementInput}");
    }
}
