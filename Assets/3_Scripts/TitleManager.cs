﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    public void ClickStart()
    {
        SceneManager.LoadScene("Game");

        // SceneManager.LoadScene("Game", LoadSceneMode.Additive); // 씬을 두개 이상 같이 띄워두고 싶을 때
    }

    /*
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 100), "게임씬 나가기"))
        {
            SceneManager.UnloadScene("Game");
        }
    }
    */
    
}
