using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersatileButton : MonoBehaviour
{
    public void Purchase(int price)
    {
        //아이템 가격이 게임 매니저에 있는 머니보다 크다면
        if (price > GameManager.instance.money)
        {
            //아이템 구매x 함수 종료
            return;
        }
        else if (price <= GameManager.instance.money)
        {
            GameManager.instance.money -= price;
            GameManager.instance.dragon++;
        }

    }
    
    public void WindowOpen(GameObject window)
    {
        window.SetActive(true);
    }
    public void WindowClose(GameObject window)
    {
        window.SetActive(false);
    }
}
