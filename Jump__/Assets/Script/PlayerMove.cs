using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private Quaternion initialRotation;
    //Camera MainCamera;
    public float speed = 10f;
    public float jumpHeight = 3f;
    public float dasj = 5f;
    public float rotSpeed = 3f;

    private Vector3 dir = Vector3.zero;

    private bool ground = false;
    public LayerMask layer;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody = GetComponent<Rigidbody>();
        initialRotation = transform.rotation;
    }

    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        dir.Normalize();

        CheckGround();

        if (Input.GetButtonDown("Jump") && ground)
        {
            Vector3 jumpPower = Vector3.up * jumpHeight;
            rigidbody.AddForce(jumpPower, ForceMode.VelocityChange);
        }

        
    }

    private void FixedUpdate()
    {
        if (dir != Vector3.zero)
        {
            if (Mathf.Sign(transform.forward.x) != Mathf.Sign(dir.x) || Mathf.Sign(transform.forward.z) != Mathf.Sign(dir.z))
            {
                transform.Rotate(0, 1, 0);
            }

            transform.forward = Vector3.Lerp(transform.forward, dir, rotSpeed * Time.deltaTime);
        }

        rigidbody.MovePosition(this.gameObject.transform.position + dir * speed * Time.deltaTime);


        

         

        transform.rotation = initialRotation;
    }

    void CheckGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + (Vector3.up * 0.2f), Vector3.down, out hit, 0.4f, layer))
        {
            ground = true;
        }
        else
        {
            ground = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Block"))
        {
            
            float blockTop = collision.transform.position.y + collision.transform.localScale.y / 2f;
            Vector3 landingPosition = new Vector3(transform.position.x, blockTop, transform.position.z);
            transform.position = landingPosition;
        }
    }


}
