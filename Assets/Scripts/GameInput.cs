using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovemRentVectorNormalized()
    {
        // Binding the new input manager to the player
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }
}
