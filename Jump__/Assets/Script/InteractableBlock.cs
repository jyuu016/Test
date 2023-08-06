using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBlock : MonoBehaviour
{
    private bool playerOnBlock = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnBlock = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnBlock = false;
        }
    }

    public bool IsPlayerOnBlock()
    {
        return playerOnBlock;
    }
}

public class CostomplayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private bool canJump = false;
    private bool IsOnBlock = false;
    public float jumpForce = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            InteractableBlock block = collision.gameObject.GetComponent<InteractableBlock>();
            if (block != null && block.IsPlayerOnBlock())
            {
                canJump = true;
                IsOnBlock = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            IsOnBlock = false;
        }
    }
}


