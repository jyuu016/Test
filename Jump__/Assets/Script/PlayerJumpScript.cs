using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpScript : MonoBehaviour
{
    public float jumpForce = 5f; 
    public LayerMask groundLayer;

    [SerializeField]private bool isGrounded = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
   
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (isGrounded)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = false;
        }
    }
}
