using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(6))
        {
            collision.transform.position = new Vector2(Random.Range(-10.75f, 10.75f), Random.Range(-11.75f, 9.75f));
        }
    }

}
