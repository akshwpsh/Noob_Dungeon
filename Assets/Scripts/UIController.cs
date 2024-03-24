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
    Sequence MenuBarSequence;
    public RectTransform[] UIList;
    /// <summary>
    /// 0 -> MainPanel
    /// 1 -> EnterRoomPanel
    /// 2 -> MakeRoomPanel
    /// 3 -> MenuUI (UnderPanel에 속함)
    /// 4 -> SettingButton (MenuUI에 속함)
    /// 5 -> ExitButton(MenuUI에 속함)
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


    public void EnterRoomUIOpen()
    {
        startMenuSequence = DOTween.Sequence();
        startMenuSequence.Append(UIList[0].DOAnchorPos(new Vector2(500, 0), 0.3f));
        startMenuSequence.Append(UIList[1].DOAnchorPos(new Vector2(-30, 30), 0.3f));
        isEnterRoom = true;
    }

    public void EnterRoomUIClose()
    {
        startMenuSequence = DOTween.Sequence();
        startMenuSequence.Append(UIList[1].DOAnchorPos(new Vector2(500, 30), 0.3f));
        startMenuSequence.Append(UIList[0].DOAnchorPos(new Vector2(-30, 0), 0.3f));
        isEnterRoom = false;
    }

    public void MakeRoomUIOpen()
    {
        startMenuSequence = DOTween.Sequence();
        startMenuSequence.Append(UIList[0].DOAnchorPos(new Vector2(500, 0), 0.3f));
        startMenuSequence.Append(UIList[2].DOAnchorPos(new Vector2(0, 200), 0.5f));
        isMakeRoom = true;
    }

    public void MakeRoomUIClose()
    {
        startMenuSequence = DOTween.Sequence();
        startMenuSequence.Append(UIList[2].DOAnchorPos(new Vector2(0, -1000), 0.5f));
        startMenuSequence.Append(UIList[0].DOAnchorPos(new Vector2(-30, 0), 0.3f));
        isMakeRoom = false;
    }

    public void MenuUIOpen()
    {
        MenuBarSequence = DOTween.Sequence();
        MenuBarSequence.Append(UIList[3].DOSizeDelta(new Vector2(100, 600), 0.5f));
        MenuBarSequence.Join(UIList[4].DOAnchorPos(new Vector2(0, 0), 0.2f));
        MenuBarSequence.Join(UIList[5].DOAnchorPos(new Vector2(0, -130), 0.2f));
        isMenu = true;
    }
    public void MenuUIClose()
    {
        MenuBarSequence = DOTween.Sequence();
        MenuBarSequence.Append(UIList[3].DOSizeDelta(new Vector2(100, 100), 0.4f));
        MenuBarSequence.Join(UIList[4].DOAnchorPos(new Vector2(0, 0), 0.2f));
        MenuBarSequence.Join(UIList[5].DOAnchorPos(new Vector2(0, 0), 0.2f));
        isMenu = false;
    }
}
