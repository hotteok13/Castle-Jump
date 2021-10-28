using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Road_Manager : MonoBehaviour
{
    [SerializeField] float speed = 200;
    [SerializeField] GameObject Road;

    List<GameObject> Road_List;

    Vector3 Next_Road = Vector3.zero;

    int Last_Road, First_Road;

    private void Start()
    {
        Road_List = new List<GameObject>();
        Sound_Manager.instance.BGM_Sound("Royalty");

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


    void Move_Road()
    {
        for(int i = 0; i < Road_List.Count; i++)
        {
            Road_List[i].transform.Translate(-transform.forward * speed * Time.deltaTime);
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
