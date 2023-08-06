using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 5f;
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private bool canJump = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (canJump && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }

        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.velocity = movement * moveSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            InteractableBlock block = collision.gameObject.GetComponent<InteractableBlock>();
            if (block != null && block.IsPlayerOnBlock())
            {
                canJump = true;
            }
        }
    }
}

