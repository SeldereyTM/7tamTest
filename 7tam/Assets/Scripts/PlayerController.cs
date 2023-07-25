using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{

    private Joystick moveJoystick;
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    PhotonView view;


    void Start()
    {
        moveJoystick = GameObject.FindGameObjectWithTag("moveJoyStick").GetComponent<Joystick>();
        rb = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
    }


    void Update()
    {
        if (view.IsMine && gameObject.GetComponent<PlayerStats>().health > 0)
        {
        moveInput = new Vector2(moveJoystick.Horizontal, moveJoystick.Vertical);
        moveVelocity = moveInput * speed;
        }

    }


    private void FixedUpdate()
    {
        if (view.IsMine)
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

}
