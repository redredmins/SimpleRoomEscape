using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 게임에 필요한 기능
    // 1. 물체를 클릭했을 때,
    //   - 문 : 열쇠(아이템)가 있으면 문이 열리고, 없으면 없다고 텍스트로 띄워주기
    //   - 서랍장 : 자물쇠가 있는 서랍장이면 안 열리고 잠겼다고 알림. 없으면 그냥 열림
    //   - 자물쇠 : 잠김 상태면 자물쇠 팝업 띄워주고, 열리면 사라짐, 패스워드 존재
    //   - 메시지 텍스트 : 인터렉션이 되는 물체를 클릭했을 때, 안내문구를 띄워줌
    // 2. UI
    //   - 서랍장 내부 팝업 : 방금 누른 서랍장의 내부를 보여주기
    //   - 자물쇠 팝업 : '잠김' or '잠김해제' 상태를 텍스트로 보여줌,
    //                   버튼 키를 맞는 패스워드로 맞추면 잠김 해제.
    //   - 인벤토리 : 먹을 수 있는 아이템을 누르면 인벤토리로 들어옴


    // * 프로퍼티 : get, set
    //       1. 변수에 값을 바꾸거나 가져올 때 메서드처럼 처리하고 싶을 때
    //       2. 다른 코드에서 마음대로 바꾸면 안되는 값을 보호하고 싶을 때 (캡슐화)
    // * 싱글톤 : 디자인 패턴
    //       1. 메모리상에 하나만 존재해야하는 객체를 관리할 때
    //       2. 다른 코드에서 직접 참조하지 않고도 사용할 수 있게 만들 때


    // 프로퍼티, static
    private static GameManager manager;
    public static GameManager Manager
    {
        get
        {
            return manager;
        }

        private set
        {
            if (manager == null)
            {
                manager = value;
                //DontDestroyOnLoad(manager);
            }
            else
            {
                Destroy(value.gameObject);
            }
        }
    }

    public GameObject escapePopup;
    public Transform inventory;
    public GameObject itemSlotPrefab;
    public Text txtNotice;
    public List<Door> doors;

    bool isPopupOn;


    void Awake() // 유니티 이벤트 메서드
    {     
        Manager = this;

        isPopupOn = false;
    }

    void Update()
    {
        if (isPopupOn == true) return;

        if (Input.GetMouseButtonDown(0) == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(mousePos, Vector2.zero);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);

            foreach(var hit in hits)
            {
                IClickable clickable = hit.transform.GetComponent<IClickable>();
                if (clickable != null)
                {
                    clickable.OnClick();
                }
            }
        }
    }

    public void PutInItem(GameObject item)
    {
        string itemId = item.name;

        foreach(var door in doors)
        {
            if (door.SetHasKey(itemId) == true) item.SetActive(false);
        }

        Image itemImg = item.GetComponent<Image>();
        GameObject slotObj = Instantiate(itemSlotPrefab, inventory);
        
        RectTransform slotTrans = slotObj.GetComponent<RectTransform>();
        slotTrans.anchoredPosition = new Vector2(0f, 0f);

        UIItemSlot slot = slotObj.GetComponent<UIItemSlot>();
        slot.UpdateSlot(itemImg.sprite);
    }

    public void SetPopupOn(bool isOn)
    {
        isPopupOn = isOn;
    }

    public void ShowNotice(string notice)
    {
        txtNotice.text = notice;
    }

    public void ShowEscape()
    {
        escapePopup.SetActive(true);
        isPopupOn = true;
    }
}
