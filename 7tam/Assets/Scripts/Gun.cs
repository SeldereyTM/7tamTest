using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Gun : MonoBehaviour
{
    private Joystick aimJoystick;
    public GameObject bullet;
    public Transform shotPoint;

    private float timeBtwShots = 0;
    public float startTmeBtwShots;
    private float rotZ;

    PhotonView view;
    public Sprite secondSkin;
    SpriteRenderer sRend;
    public GameObject hand;


    void Start()
    {
        aimJoystick = GameObject.FindGameObjectWithTag("aimJoyStick").GetComponent<Joystick>();
        view = GetComponent<PhotonView>();
        sRend = hand.GetComponent<SpriteRenderer>();
        if (view.IsMine == false)
        {
            sRend.sprite = secondSkin;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            RotateGun();

            if (timeBtwShots <= 0)
            {
                if (Mathf.Abs(aimJoystick.Vertical) > 0.6f || Mathf.Abs(aimJoystick.Horizontal) > 0.6f)
                {

                    timeBtwShots = startTmeBtwShots;

                    PhotonNetwork.Instantiate(bullet.name, shotPoint.position, transform.rotation);
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
            
    }


    void RotateGun()
    {
        if (aimJoystick.Vertical != 0f || aimJoystick.Horizontal != 0f)
        {
        rotZ = Mathf.Atan2(aimJoystick.Vertical, aimJoystick.Horizontal) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }

        Vector3 LocalScale = Vector3.one;

        if (rotZ > 90 || rotZ < -90)
        {
            LocalScale.y = -1f;
        }
        else
        {
            LocalScale.y = +1f;
        }

        transform.localScale = LocalScale;
    }

}
