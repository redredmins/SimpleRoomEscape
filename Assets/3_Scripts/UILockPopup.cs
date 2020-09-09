using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILockPopup : MonoBehaviour
{
    // - 자물쇠 팝업 : '잠김' or '잠김해제' 상태를 텍스트로 보여줌,
    //                 버튼 키를 맞는 패스워드로 맞추면 잠김 해제.


    public Text txtLockState;
    public Image[] imgLockButtons; // btn0      btn1       btn2      btn3
    public Sprite[] colorButtonSprites; // 0:빨강 / 1:노랑 / 2:초록 / 3:파랑

    CombiLock combiLock;
    CombiLock.LockButtonColor[] password;
    CombiLock.LockButtonColor[] curButtons;


    public void InitPopup(CombiLock combiLock, CombiLock.LockButtonColor[] pw)
    {
        this.combiLock = combiLock;
        password = pw;
        txtLockState.text = "잠금";

        curButtons = new CombiLock.LockButtonColor[pw.Length];

        for (int i = 0; i < curButtons.Length; ++i)
        {
            curButtons[i] = CombiLock.LockButtonColor.Red;

            int ci = (int)curButtons[i];
            imgLockButtons[i].sprite = colorButtonSprites[ci];
        }
    }

    public void ClickLockButton(int index)
    {
        int nextColor = ((int)curButtons[index] + 1) % (int)CombiLock.LockButtonColor.Max;
        curButtons[index] = (CombiLock.LockButtonColor)nextColor;

        imgLockButtons[index].sprite = colorButtonSprites[nextColor];

        // check
        int check = 0;
        for(int i = 0; i < curButtons.Length; ++i)
        {
            if (curButtons[i] == password[i]) check += 1;
        }

        if (check == password.Length)
        {
            // unlock
            txtLockState.text = "잠금해제";
            combiLock.Unlock();
        }
    }
}
