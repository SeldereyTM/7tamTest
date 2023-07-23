using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Joystick aimJoystick;
    public GameObject bullet;
    public Transform shotPoint;

    private float timeBtwShots = 0;
    public float startTmeBtwShots;
    private float rotZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            RotateGun();

            if (timeBtwShots <= 0)
            {
                if (Mathf.Abs(aimJoystick.Vertical) > 0.6f || Mathf.Abs(aimJoystick.Horizontal) > 0.6f)
                {

                    timeBtwShots = startTmeBtwShots;

                    Instantiate(bullet, shotPoint.position, transform.rotation);
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
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
