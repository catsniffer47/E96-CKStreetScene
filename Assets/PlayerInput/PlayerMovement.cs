using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float JumpVelocity = 5;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float bulletspeed = 10;

    [SerializeField]
    float WalkSpeed = 5;

    [SerializeField]
    bool OnGround = false;

    //I tried my best to make a separate logic module. I tried. Dearly.
    [SerializeField]
    TMP_Text bulletUI;

    [SerializeField]
    int bulletcount = 10;

    Rigidbody rb;
    bool CanDoubleJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        bulletUI.text = bulletcount.ToString();
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

    void OnFire()
    {
        Debug.Log("Firing!");

        if (bulletcount > 0)
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position + 0.5f * transform.forward, Quaternion.identity);
            Rigidbody bulletRigidBody = bulletInstance.GetComponent<Rigidbody>();

            bulletRigidBody.AddForce(bulletspeed * transform.forward);
            bulletcount -= 1;
            bulletUI.text = bulletcount.ToString();
        }
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
