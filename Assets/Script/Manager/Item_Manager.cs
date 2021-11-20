using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public Sprite Part;
    public int Purchase;
    public string Price;
}

public class Item_Manager : MonoBehaviour
{
    [SerializeField] Item[] item;

    [SerializeField] Text[] price;
    [SerializeField] Image[] part; 

    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            part[i].sprite = item[i].Part;
            price[i].text = item[i].Price;
        }
    }

    private void Update()
    {
        GameManager.instance.purchase_Active(item[0].Purchase, item[1].Purchase, item[2].Purchase);
    }

}
