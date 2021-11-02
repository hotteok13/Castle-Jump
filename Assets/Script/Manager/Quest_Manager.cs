using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Quest
{
    public int Reward;
    public string Explanation;

}

public class Quest_Manager : MonoBehaviour
{
    static int Count;
    [SerializeField] Text Quest_Currency;
    [SerializeField] Text Quest_Explanation;
    
    public Quest [] quest;

    private void Start()
    {
        Quest_List();
    }

    void Quest_List()
    {
        switch(Count)
        {
            case 0:
                Quest_Explanation.text = quest[0].Explanation.ToString();
                Quest_Currency.text = quest[0].Reward.ToString();

                GameManager.instance.Quest_Currecny(quest[0].Reward);
                break;
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;


        }
    }




}
