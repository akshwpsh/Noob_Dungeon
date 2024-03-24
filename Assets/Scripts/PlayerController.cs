using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public static PlayerController Instance;
    [Header("Base setup")]
    public float walkSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOwner)
        {
            Instance = this;
        }
           
        Move();
    }

    public void Move()
    {
        if (base.IsOwner)
        {
            if(Input.GetKey(KeyCode.W))
            {
                transform.position += transform.up * walkSpeed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.up * walkSpeed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.A))
            {
                transform.position -= transform.right * walkSpeed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * walkSpeed * Time.deltaTime;
            }
        }
    }
}
