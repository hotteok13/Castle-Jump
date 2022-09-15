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
        //Start 함수 이전에 시작이 된다
        
        // 게임 데이터를 게임이 시작할 때 불러옵니다.
        Load();

        if (instance == null)
        {
            instance = this;
        }
    }

    

    public void Save()
    {
        // PlayerPrefs.SetInt 정수형 데이터를 저장하는 함수
        // KEY - VALUE를 가지고 저장합니다.
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("Dragon", dragon);
    }

    public void Load()
    {
        // PlayerPrefs.GetInt 정수형 데이터를 불러오는 함수
        score = PlayerPrefs.GetInt("Score");
        money = PlayerPrefs.GetInt("Money");
        dragon = PlayerPrefs.GetInt("Dragon");
    }
}
