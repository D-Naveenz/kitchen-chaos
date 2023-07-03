using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    private bool isWalking;
    
    public bool IsWalking
    { 
        get
        {
            return isWalking;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Binding a legacy input manager to the player
        Vector2 inputVector = new(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
        }

        // normalizing the movement
        inputVector = inputVector.normalized;

        // 2D plane of the inputVector is in horizontaly. So we need to convert it to a vertical plane using a 3D vector
        Vector3 moveDirection = new(inputVector.x, 0f, inputVector.y);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        // setting the animation
        isWalking = moveDirection != Vector3.zero;

        // rotating the player according to the movement direction
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
    }
}
