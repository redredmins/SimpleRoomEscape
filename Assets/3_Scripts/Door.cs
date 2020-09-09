using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // - 문 : 열쇠(아이템)가 있으면 문이 열리고, 없으면 없다고 텍스트(UI)로 띄워주기

    public Sprite closeDoorSprite;
    public Sprite openDoorSprite;

    SpriteRenderer renderer;
    //GameManager manager;
    

    // void OnEnable() // 주로 초기화 코드를 작성

    void Start() // 초기화
    {
        //manager = GameManager.Manager; // 캐싱(최적화)

        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = closeDoorSprite;
    }

    public void ClickDoor(bool hasKey)
    {
        if (hasKey == true)
        {
            renderer.sprite = openDoorSprite;
        }
        else
        {
            GameManager.Manager.ShowNotice("문이 잠겨있습니다.");
        }
    }
}
