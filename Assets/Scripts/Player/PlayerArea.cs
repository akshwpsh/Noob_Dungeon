using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public class PlayerArea : NetworkBehaviour
{
    public GameObject area;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetArea();
    }
    
    void SetArea()
    {
        if (base.IsOwner)
        {
            area.SetActive(true);
        }
    }
}
