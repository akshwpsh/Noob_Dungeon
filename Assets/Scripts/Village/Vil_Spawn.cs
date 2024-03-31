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
        Debug.Log("캐릭터 생성해야함");
        
        PlayerSpawner.Instantiate(player); //<-- 인스턴스로 처리해보기
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
