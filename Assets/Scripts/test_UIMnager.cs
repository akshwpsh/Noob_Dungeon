using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class test_UIMnager : MonoBehaviour
{
    public TMP_InputField inputField;
    
    public async void OnClickHost()
    {
        string joinCode = await RelayManager.Instance.StartHostWithRelay();
        inputField.text = joinCode;
    }
    
    public async void OnClickJoin()
    {
        await RelayManager.Instance.StartClientWithRelay(inputField.text);
    }
}
