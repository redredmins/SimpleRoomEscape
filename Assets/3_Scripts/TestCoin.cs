using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoin
{
    public void SetCoin(int newCoin)
    {
        PlayerPrefs.SetInt("COIN", newCoin);
        coin = newCoin;
    }
    public int GetCoin()
    {
        return coin;
    }

    // 프로퍼티
    private int coin;
    public int Coin // 캡슐화
    {
        set
        {
            if (value < 0)
            {
                coin = 0;
            }
            else if (value > 1000000)
            {
                coin = 0;
            }
            else
            {
                coin = value;
            }

            PlayerPrefs.SetInt("COIN", value);
        }
        get
        {
            //Debug.Log("아이고 내 돈...");
            return coin;
        }
    }

    public void UpdateCoin(int addValue)
    {
        
        Coin += addValue;
    }




}
