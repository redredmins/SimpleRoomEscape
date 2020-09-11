using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster // 추상 클래스
{
    protected string name;
    protected int hp;
    protected int damage;
    public string sound;


    public Monster(string name)
    {
        this.name = name;
    }
    
    protected void Attack()
    {
        Debug.Log("공격한다!!");
    }

    protected void Talk()
    {
        Debug.Log(sound + " 라고 말한다!!");
    }

    protected void Eat()
    {
        Debug.Log("먹는다!!");
    }

    public abstract void Sleep(string sleepSound);

    public virtual void FindPlayerAction()
    {
        Debug.Log(name + "이(가) 플레이어를 만났다.");
    }

}

public class Orc : Monster, IArchor
{
    int defence;

    public Orc(string name, string sound, int defence) : base(name)
    {
        this.sound = sound;
        this.defence = defence;
    }

    public override void FindPlayerAction()
    {
        base.FindPlayerAction(); // 부모가 구현해둔 메서드를 실행

        Talk();
        Attack();
    }

    public void DoOnlyOrc()
    {
        Debug.Log("오크만 이빨을 드러낼 수 있지!");
    }

    public override void Sleep(string sleepSound)
    {
        Debug.Log(sleepSound);
        Debug.Log(sleepSound);
    }

    public void ShootBow()
    {
        Debug.Log("오크는 활을 따닷! 따닷! 쏜다!");
    }

}

public sealed class Troll : Monster, IWalkable
{
    // sealed : 더이상 상속하지 못하게 만드는 한정자

    public int walkedDistance
    {
        get { return 1; }
    }

    public void Walk()
    {
        Debug.Log("트롤은 터덜터덜 걷는다.");
    }

    public Troll(string name, int hp) : base(name)
    {
        this.hp = hp;
    }

    public override void FindPlayerAction()
    {
        Eat();
        Attack();
    }

    public void DoOnlyTroll()
    {
        Debug.Log("트롤만 자연회복 할 수 있지!");
    }

    public override void Sleep(string sleepSound)
    {
        Debug.Log(sleepSound + " Zzzzz...");
    }
}

public class KingTroll // : Troll
{
    public KingTroll(string name, int hp) // : base(name, hp)
    {

    }
}
