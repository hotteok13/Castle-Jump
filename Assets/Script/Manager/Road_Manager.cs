using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Road_Manager : MonoBehaviour
{
    [SerializeField] RectTransform Position;

    GameObject Road;
    List<GameObject> Road_List;

    Vector3 Next_Road = Vector3.zero;

    int Last_Road, First_Road;

    private void Start()
    {
        Road_State();

        Road_List = new List<GameObject>();

        for (int i = 0; i < 3; i++)
        {
            Road_List.Add(Instantiate(Road, Next_Road, Quaternion.identity));
            Next_Road += Vector3.forward * 200f;
        }
    }

    private void Update()
    {
        if (!GameManager.Game_Operation) return;

        Move_Road();
    }

    void Road_State()
    {
        switch (GameManager.Road_Count)
        {
            case 0:
                Sound_Manager.instance.BGM_Sound("Royalty");
                Road = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/First Road.prefab", typeof(GameObject));
                GameManager.Rate = 1000;
                break;
            case 1:
                Sound_Manager.instance.BGM_Sound("Presentations");
                Road = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Second Road.prefab", typeof(GameObject));
                Position.anchoredPosition = new Vector3(150, 175, 0);
                GameManager.Rate = 500;
                break;
            case 2:
                Sound_Manager.instance.BGM_Sound("Powerful");
                Road = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Three Road.prefab", typeof(GameObject));
                Position.anchoredPosition = new Vector3(125, 150, 0);
                GameManager.Rate = 100;
                break;
            case 3:
                Sound_Manager.instance.BGM_Sound("Instrumental");
                Road = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Four Road.prefab", typeof(GameObject));
                Position.anchoredPosition = new Vector3(100, 125, 0);
                GameManager.Rate = 50;
                break;
        }
    }

    void Move_Road()
    {
        for(int i = 0; i < Road_List.Count; i++)
        {
            Road_List[i].transform.Translate(-transform.forward * GameManager.Speed * Time.deltaTime);
        }

        if(Road_List[Last_Road].transform.position.z <= -200)
        {
            GameManager.instance.vehicle_Km();
            GameManager.instance.Json_Save();
      
            First_Road = Last_Road - 1;

            if(First_Road < 0)
            {
                First_Road = Road_List.Count - 1;
            }

            Road_List[Last_Road].transform.position = Road_List[First_Road].transform.position + Vector3.forward * 200;

            Last_Road++;

            if(Last_Road >= Road_List.Count)
            { 
                Last_Road = 0;
            }
        }
    }

}
