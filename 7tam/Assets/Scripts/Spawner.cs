using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawner : MonoBehaviour
{

    public GameObject Coin;


    void Start()
    {
        for (int i = 0; i < 75; i++ )
        {
            Vector2 randomPos = new Vector2(Random.Range(-10.75f, 10.75f), Random.Range(-11.75f, 9.75f));
            PhotonNetwork.Instantiate(Coin.name, randomPos, Quaternion.identity);
        }
    }

}
