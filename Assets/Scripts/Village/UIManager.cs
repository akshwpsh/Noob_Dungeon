using FishNet;
using FishNet.Managing.Scened;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private string VillageScene = "Village";
    [SerializeField] private string MainScene = "Main";

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }


    // Update is called once per frame
    void Update()
    {
        //�������� Ȯ�� �ƴϸ� �Ա���
        if (!InstanceFinder.IsServer) return;

        if(Input.GetKeyUp(KeyCode.P))
        {
            LoadScene(VillageScene);
            UnLoadScene(MainScene);
        }


    }

    public void GotoVillage() //���������� �̵��ϴ� �Լ�
    {
        LoadScene(VillageScene);
        UnLoadScene(MainScene);
    }


    /// <summary>
    /// �Ķ���ͷ� �� �̸� ������ fishnet �� �̵� �ϴ� �Լ�
    /// </summary>
    /// <param name="sceneName"></param>
    void LoadScene(string sceneName)
    {
        //�������� Ȯ�� �ƴϸ� �Ա���
        if (!InstanceFinder.IsServer) return;

        SceneLoadData sld = new SceneLoadData(sceneName);
        InstanceFinder.SceneManager.LoadGlobalScenes(sld);

    }

    /// <summary>
    /// �Ķ���ͷ� �� �̸� ������ ������ �ִ� �� ��ε��ϴ� �Լ�
    /// </summary>
    void UnLoadScene(string sceneName)
    {
        if (!InstanceFinder.IsServer) return;

        SceneUnloadData sld = new SceneUnloadData(sceneName);
        InstanceFinder.SceneManager.UnloadGlobalScenes(sld);
    }
}
