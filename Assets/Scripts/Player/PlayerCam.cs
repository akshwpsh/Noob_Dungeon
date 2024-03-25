using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public class PlayerCam : NetworkBehaviour
{
    public GameObject cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetCamera();
    }
    
    void SetCamera()
    {
        if (base.IsOwner)
        {
            cam.SetActive(true);
        }
    }
}
