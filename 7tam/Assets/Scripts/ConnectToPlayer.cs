using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ConnectToPlayer : MonoBehaviour
{
    public static CinemachineVirtualCamera myCinemachine;


    void Start()
    {
        myCinemachine = GetComponent<CinemachineVirtualCamera>();
    }


    public static void Connect(GameObject player)
    {
        myCinemachine.m_Follow = player.transform;
    }
}
