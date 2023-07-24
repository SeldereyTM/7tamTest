using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject Coin;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 150; i++ )
        {
            Vector2 randomPos = new Vector2(Random.Range(-10.75f, 10.75f), Random.Range(-11.75f, 9.75f));
            Instantiate(Coin, randomPos, Quaternion.identity);
        }
    }

}
