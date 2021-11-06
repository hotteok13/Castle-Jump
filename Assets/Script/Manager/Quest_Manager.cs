using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Quest
{
    public int Reward;
    public string Explanation;

    public Quest(string explanation, int reward)
    {
        Explanation = explanation;
        Reward = reward;
    }
}

public class Quest_Manager : MonoBehaviour
{
    static int Count;

    Dictionary<int, Quest> quest_data = new Dictionary<int, Quest>();

    [SerializeField] Text Quest_Currency;
    [SerializeField] Text Quest_Explanation;
    
    private void Start()
    {
        quest_data.Add(1, new Quest("Drive at least 100 km/L.", 1000));
        quest_data.Add(2, new Quest("Drive at least 150 km/L.", 1250));
        quest_data.Add(3, new Quest("Drive at least 100 km/L.", 1500));
        quest_data.Add(4, new Quest("Drive at least 100 km/L.", 1750));

        Quest_List();
    }

    void Quest_List()
    {
        switch(Count)
        {
            case 0:
                Quest_Explanation.text = quest_data[1].Explanation;
                Quest_Currency.text = quest_data[1].Reward.ToString();

                GameManager.instance.Quest_Currecny(quest_data[1].Reward);
                break;
            case 1:
                Quest_Explanation.text = quest_data[2].Explanation;
                Quest_Currency.text = quest_data[2].Reward.ToString();

                GameManager.instance.Quest_Currecny(quest_data[2].Reward);
                break;
            case 2:
                Quest_Explanation.text = quest_data[3].Explanation;
                Quest_Currency.text = quest_data[3].Reward.ToString();

                GameManager.instance.Quest_Currecny(quest_data[3].Reward);
                break;
            case 3:
                Quest_Explanation.text = quest_data[4].Explanation;
                Quest_Currency.text = quest_data[4].Reward.ToString();

                GameManager.instance.Quest_Currecny(quest_data[4].Reward);
                break;
        }
    }




}
