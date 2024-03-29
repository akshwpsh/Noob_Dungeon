using System;
using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using Unity.VisualScripting;
using UnityEngine;

public class MapRepos : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D other)
    {
        if(!other.CompareTag("Area"))
            return;
        
        GameObject player = PlayerController.Instance.gameObject;
        Vector3 playerPos = player.transform.position;
        Vector3 myPos = transform.position;
        float dirX = playerPos.x - myPos.x;
        float dirY = playerPos.y - myPos.y;
        
        float diffx = Mathf.Abs(dirX);
        float diffy = Mathf.Abs(dirY);

        dirX = dirX > 0 ? 1 : -1;
        dirY = dirY > 0 ? 1 : -1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffx > diffy)
                {
                    transform.Translate(transform.right * dirX * 100);
                }
                else if (diffx < diffy)
                {
                    transform.Translate(transform.up * dirY * 100);
                }
                break;
        }
    }
}
