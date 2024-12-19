using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float jumpAmount = 200f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        RotatePlayer();
        ChangeSpeed();
        Jump();
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    private void ChangeSpeed()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed += 1f;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed -= 5f;
        }
    }

    private void Jump()
    {
        // TODO: Prevent double jumps. Or only jump while on ground.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(Vector2.up * jumpAmount);
        }
    }
}
