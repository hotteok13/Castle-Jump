using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public int money;
    public int dragon;
    public bool state;

    private void Awake()
    {
        //Start �Լ� ������ ������ �ȴ�
        
        // ���� �����͸� ������ ������ �� �ҷ��ɴϴ�.
        Load();

        if (instance == null)
        {
            instance = this;
        }
    }

    

    public void Save()
    {
        // PlayerPrefs.SetInt ������ �����͸� �����ϴ� �Լ�
        // KEY - VALUE�� ������ �����մϴ�.
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("Dragon", dragon);
    }

    public void Load()
    {
        // PlayerPrefs.GetInt ������ �����͸� �ҷ����� �Լ�
        score = PlayerPrefs.GetInt("Score");
        money = PlayerPrefs.GetInt("Money");
        dragon = PlayerPrefs.GetInt("Dragon");
    }
}
