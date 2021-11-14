using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
class Information
{
    public string Area;
    public Sprite Town;
    public string Explanation;
}

public class Information_Manager : MonoBehaviour
{
    [SerializeField] Text Zone;
    [SerializeField] Image City;
    [SerializeField] Text explanation;

    [SerializeField] Information [] information;

    void Start()
    {
        switch (GameManager.Road_Count)
        {
            case 0:
                Zone.text = information[0].Area;
                City.sprite = information[0].Town;
                explanation.text = information[0].Explanation;
                break;
            case 1:
                Zone.text = information[1].Area;
                City.sprite = information[1].Town;
                explanation.text = information[1].Explanation;
                break;
            case 2:
                Zone.text = information[2].Area;
                City.sprite = information[2].Town;
                explanation.text = information[2].Explanation;
                break;
            case 3:
                Zone.text = information[3].Area;
                City.sprite = information[3].Town;
                explanation.text = information[3].Explanation;
                break;
        }
    }


}
