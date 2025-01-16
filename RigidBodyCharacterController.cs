using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyCharacterController : MonoBehaviour
{
    Rigidbody Moving;
    Vector3 playerInput;
    bool jump = false;

    float playerSpeed = 3.5f;
    void Start()
    {
        Moving = GetComponent<Rigidbody>();
        Moving.freezeRotation = true;
        Moving.mass = 1;
    }

    void Update()
    {
        playerInput = new Vector3(-Input.GetAxisRaw("Horizontal"),

          0, -Input.GetAxisRaw("Vertical"));
        playerInput = playerInput.normalized * playerSpeed;

        playerInput.y = Moving.velocity.y;

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        if (jump)
        {
            Moving.drag = 0.5f;
            Moving.AddForce(Vector3.up * 5, ForceMode.Impulse);
            jump = false;
        }
        else
        {
            Moving.drag = 0;
            Moving.velocity = playerInput;
        }
    }
}
