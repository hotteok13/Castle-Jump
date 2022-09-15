using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersatileButton : MonoBehaviour
{
    public void Purchase(int price)
    {
        //������ ������ ���� �Ŵ����� �ִ� �ӴϺ��� ũ�ٸ�
        if (price > GameManager.instance.money)
        {
            //������ ����x �Լ� ����
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
