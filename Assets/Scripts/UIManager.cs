using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void OnClickStartHost()
    {
        //호스트 시작
        RelayManager.Instance.StartHostWithRelay();
    }
    
}
