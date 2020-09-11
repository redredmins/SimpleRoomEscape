using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombiLock : MonoBehaviour, IClickable
{
    // - 자물쇠 : 잠김 상태면 자물쇠 팝업 띄워주고, 열리면 사라짐. 패스워드 존재.

    public enum LockButtonColor : int
    {
        Red = 0,
        Yellow,
        Green,
        Blue,
        Max
    }

    public LockButtonColor[] password;
    public UILockPopup lockPopup;
    bool isLock;
    public bool IsLock
    {
        get
        {
            return isLock;
        }
    }

    LockButtonColor[] curButtons;
    
    
    void Start()
    {
        isLock = true;
        curButtons = new LockButtonColor[4];
    }

    public void OnClick()
    {
        if (isLock == true)
        {
            SetPopupOn(true);
        }
    }

    void SetPopupOn(bool isOn)
    {
        lockPopup.gameObject.SetActive(isOn);
        if (isOn) lockPopup.InitPopup(this, password);

        GameManager.Manager.SetPopupOn(isOn);
    }

    public void CloseLockPopup()
    {
        SetPopupOn(false);
    }
    
    public void Unlock()
    {
        isLock = false;
        gameObject.SetActive(false);
    }
}
