using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;


    void Start()
    {
        
        Vector2 randomPos = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(-8.5f, 6.5f));
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);
        GameObject gun = player.transform.Find("hand/Gun").gameObject;
        ConnectToPlayer.Connect(gun);
    }

}
