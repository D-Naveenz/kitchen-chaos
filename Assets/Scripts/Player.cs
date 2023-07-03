using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    
    public bool IsWalking { get; private set; }

    // Update is called once per frame
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovemRentVectorNormalized();
        Vector3 moveDirection = new(inputVector.x, 0f, inputVector.y);  // 2D plane of the inputVector is in horizontaly. So we need to convert it to a vertical plane using a 3D vector

        HandleMovement(moveDirection);
        HandleInteractions();
    }

    private void HandleMovement(Vector3 moveDirection)
    {
        float rotateSpeed = moveSpeed / 2 * 3;
        float playerRadius = 0.7f;
        float playerHeight = 2f;
        float moveDistance = moveSpeed * Time.deltaTime;

        // checking whether the player can move in the direction of the moveDirection
        if (!Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection, moveDistance))
        {
            transform.position += moveDirection * moveDistance;
            // setting the animation
            IsWalking = moveDirection != Vector3.zero;
        }
        else
        {
            // if player cann't move to the direction, then we need to check whether the player can move to the x or z direction
            Vector3 moveToX = new Vector3(moveDirection.x, 0f, 0f).normalized;
            Vector3 moveToZ = new Vector3(0f, 0f, moveDirection.z).normalized;

            if (!Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveToX, moveDistance))
            {
                moveDirection = moveToX;
                transform.position += moveDirection * moveDistance;
                // setting the animation
                IsWalking = moveDirection != Vector3.zero;
            }
            else if (!Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveToZ, moveDistance))
            {
                moveDirection = moveToZ;
                transform.position += moveDirection * moveDistance;
                // setting the animation
                IsWalking = moveDirection != Vector3.zero;
            }
            else
            {
                // player cann't move to any direction
                IsWalking = false;
            }
        }

        // rotating the player according to the movement direction
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
    }

    private void HandleInteractions()
    {
        float interactDistance = 2f;
        Vector3 InteractDirection = transform.forward;

        // checking whether the player can interact with the object in front of him
        if (Physics.Raycast(transform.position, InteractDirection, out RaycastHit hit, interactDistance))
        {
            if (hit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                clearCounter.Interact();
            }
        }
    }
}
