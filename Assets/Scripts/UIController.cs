using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private bool isMenu;
    public bool isMakeRoom;
    public bool isEnterRoom;
    public DOTweenAnimation menuUIAnim;

    Sequence startMenuSequence;
    public RectTransform[] PanelList;
    /// <summary>
    /// 0 -> MainPanel
    /// 1 -> EnderRoomPanel
    /// 2 -> MakeRoomPanel
    /// </summary>

    private void Awake()
    {
        isMenu = false;
        isEnterRoom = false;
        isMakeRoom = false;
    }
    public void MenuControll()
    {
        if (!isMenu)
        {
            MenuUIOpen();
        }
        else
        {
            MenuUIClose();
        }
    }
    private void MenuUIOpen()
    {
        menuUIAnim.DORestartById("Open");
        isMenu = true;
    }

    private void MenuUIClose()
    {
        menuUIAnim.DORestartById("Close");
        isMenu = false;
    }

    public void EnterRoomUIOpen()
    {
        startMenuSequence = DOTween.Sequence();
        startMenuSequence.Append(PanelList[0].DOAnchorPos(new Vector2(500, 0), 0.3f));
        startMenuSequence.Append(PanelList[1].DOAnchorPos(new Vector2(-30, 30), 0.3f));
        isEnterRoom = true;
    }

    public void EnterRoomUIClose()
    {
        startMenuSequence = DOTween.Sequence();
        startMenuSequence.Append(PanelList[1].DOAnchorPos(new Vector2(500, 30), 0.3f));
        startMenuSequence.Append(PanelList[0].DOAnchorPos(new Vector2(-30, 0), 0.3f));
        isEnterRoom = false;
    }

    public void MakeRoomUIOpen()
    {
        startMenuSequence = DOTween.Sequence();
        startMenuSequence.Append(PanelList[0].DOAnchorPos(new Vector2(500, 0), 0.3f));
        startMenuSequence.Append(PanelList[2].DOAnchorPos(new Vector2(0, 200), 0.5f));
        isMakeRoom = true;
    }

    public void MakeRoomUIClose()
    {
        startMenuSequence = DOTween.Sequence();
        startMenuSequence.Append(PanelList[2].DOAnchorPos(new Vector2(0, -1000), 0.5f));
        startMenuSequence.Append(PanelList[0].DOAnchorPos(new Vector2(-30, 0), 0.3f));
        isMakeRoom = false;
    }
}
