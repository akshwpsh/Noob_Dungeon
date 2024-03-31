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
        //서버인지 확인 아니면 입구컷
        if (!InstanceFinder.IsServer) return;

        if(Input.GetKeyUp(KeyCode.P))
        {
            LoadScene(VillageScene);
            UnLoadScene(MainScene);
        }


    }

    public void GotoVillage() //마을씬으로 이동하는 함수
    {
        LoadScene(VillageScene);
        UnLoadScene(MainScene);
    }


    /// <summary>
    /// 파라미터로 씬 이름 넣으면 fishnet 씬 이동 하는 함수
    /// </summary>
    /// <param name="sceneName"></param>
    void LoadScene(string sceneName)
    {
        //서버인지 확인 아니면 입구컷
        if (!InstanceFinder.IsServer) return;

        SceneLoadData sld = new SceneLoadData(sceneName);
        InstanceFinder.SceneManager.LoadGlobalScenes(sld);

    }

    /// <summary>
    /// 파라미터로 씬 이름 넣으면 기존에 있던 씬 언로드하는 함수
    /// </summary>
    void UnLoadScene(string sceneName)
    {
        if (!InstanceFinder.IsServer) return;

        SceneUnloadData sld = new SceneUnloadData(sceneName);
        InstanceFinder.SceneManager.UnloadGlobalScenes(sld);
    }
}
