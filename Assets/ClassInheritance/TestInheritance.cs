using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInheritance : MonoBehaviour
{
    
    void Start()
    {
        Orc orc = new Orc("지나가는 오크", "옼! 옼!", 10);
        Troll troll = new Troll("서있는 트롤", 100);


        // Debug.Log("----- 오크가 플레이어를 만났다!");
        // orc.FindPlayerAction();

        // Debug.Log("----- 트롤이 플레이어를 만났다!");
        // troll.FindPlayerAction();


        // Monster monster = new Monster("뭔지 모를 몬스터");
        //monster.FindPlayerAction();


        Monster[] monsters = new Monster[2];
        monsters[0] = orc;      // 자식클래스 -> 부모클래스 : 업캐스팅
        monsters[1] = troll;

        //Orc newOrc = (Orc)monsters[1]; // 부모클래스 -> 자식클래스 형태로 바꾸기 : 다운캐스팅

        //monsters[0].DoOnlyOrc(); // 자식이 구현한 내용을 부모가 사용할 수 없음

        foreach (var mon in monsters)
        {
            mon.FindPlayerAction();
            mon.Sleep(mon.sound);
        }

    }

}
