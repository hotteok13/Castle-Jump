using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle_Manager : MonoBehaviour
{
    [SerializeField] GameObject Prefabs;

    List<GameObject> list = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            list.Add(Instantiate(Prefabs, transform.position, Quaternion.identity));
        }

        list[0].transform.position = Vector3.right * 60 + Vector3.forward * 250;
        list[1].transform.position = Vector3.right + Vector3.forward * 300;
        list[2].transform.position = Vector3.right * -60 + Vector3.forward * 350;

        for (int i = 0; i < list.Count; i++)
        {
            list[Random.Range(0,3)].SetActive(false);        
        }
    }

    void Vehicle_Move()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].transform.Translate(-transform.forward * Random.Range(50, 150) * Time.deltaTime);

            if (list[i].transform.position.z <= -200)
            {
                for (i = 0; i < list.Count; i++)
                {
                    list[i].SetActive(true);
                    list[Random.Range(0, 3)].SetActive(false);
                }

                list[0].transform.position = Vector3.right * 60 + Vector3.forward * 250;
                list[1].transform.position = Vector3.right + Vector3.forward * 300;
                list[2].transform.position = Vector3.right * -60 + Vector3.forward * 350;
            }
        }

    }

    void Update()
    {
        if (!GameManager.Game_Operation) return;

        Vehicle_Move(); 
    }


}
