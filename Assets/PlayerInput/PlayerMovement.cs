using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float JumpVelocity = 5;

    [SerializeField]
    float WalkSpeed = 5;

    [SerializeField]
    bool OnGround = false;

    Rigidbody rb;
    bool CanDoubleJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        Debug.Log(input);

        rb.velocity = input.y * transform.forward + input.x * transform.right;
        rb.velocity *= WalkSpeed;
    }

    void OnJump()
    {
        if (OnGround)
        {
            rb.velocity += transform.up * JumpVelocity;
        }
        else if (CanDoubleJump) //implement double jump
        {
            rb.velocity += transform.up * JumpVelocity;
            CanDoubleJump = false;
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            OnGround = false;
            CanDoubleJump = true;
        }
    }
}
