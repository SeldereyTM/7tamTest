using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float
    speed,
    distance;

    public int damage;
    public LayerMask whatIsSolid;

    public Transform holePoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Target"))
            {
                
                //Instantiate(bloodShot, holePoint.position, transform.rotation);
                //hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);

            }
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }


}
