using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IArchor
{
    // 인터페이스에 변수는 선언할 수 X
    // 프로퍼티, 메서드만 선언할 수 있고, 실행 코드는 넣지 못함
    // 인터페이스에 선언되는 프로퍼티와 메서드는 접근제한자를 쓰지 않음

    void ShootBow();
}

public interface IWalkable
{
    int walkedDistance { get; }
    void Walk();
}

public partial class Hero : IArchor, IWalkable
{
    public int walkedDistance
    {
        get { return 0; }
    }

    public void ShootBow()
    {
        Debug.Log("히어로가 활을 쏜다! 슝슝!");
    }

    public void Walk()
    {
        Debug.Log("히어로는 당당히 걷는다!");
    }
    
}
