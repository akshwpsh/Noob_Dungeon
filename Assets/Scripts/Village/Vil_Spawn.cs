using FishNet;
using FishNet.Component.Spawning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vil_Spawn : MonoBehaviour
{
    public GameObject player;
    public GameObject fd;

    void Start()
    {
        Debug.Log("ĳ���� �����ؾ���");
        
        PlayerSpawner.Instantiate(player); //<-- �ν��Ͻ��� ó���غ���
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
