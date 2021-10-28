using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle_Manager : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject Prefabs, Different_Prefab;

    List<GameObject> list = new List<GameObject>();
    List<GameObject> Different_list = new List<GameObject>();


    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            list.Add(Instantiate(Prefabs, transform.position, Quaternion.identity));
            Different_list.Add(Instantiate(Different_Prefab, transform.position, Quaternion.identity));
        }

        for (int i = 0; i < list.Count; i++)
        {
            list[Random.Range(0, 3)].SetActive(false);
            Different_list[Random.Range(0, 3)].SetActive(false);
        }

        list[0].transform.position = Vector3.right * 60 + Vector3.forward * 300;
        list[1].transform.position = Vector3.right + Vector3.forward * 325;
        list[2].transform.position = Vector3.right * -60 + Vector3.forward * 350;

        Different_list[0].transform.position = Vector3.right * 60 + Vector3.forward * 350;
        Different_list[1].transform.position = Vector3.right + Vector3.forward * 400;
        Different_list[2].transform.position = Vector3.right * -60 + Vector3.forward * 450;
    }

    void Update()
    {
        if (!GameManager.Game_Operation) return;

        Vehicle_Move();
    }

    void Vehicle_Move()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].transform.Translate(-transform.forward * speed * Time.deltaTime);
            Different_list[i].transform.Translate(-transform.forward * speed * Time.deltaTime);

            if (list[i].transform.position.z <= -250)
            {
                for (i = 0; i < list.Count; i++)
                {              
                    list[i].SetActive(true);
                    list[Random.Range(0, 3)].SetActive(false);

                    Different_list[i].SetActive(true);
                    Different_list[Random.Range(0, 3)].SetActive(false);
                }

                list[0].transform.position = Vector3.right * 60 + Vector3.forward * 300;
                list[1].transform.position = Vector3.right + Vector3.forward * 325;
                list[2].transform.position = Vector3.right * -60 + Vector3.forward * 350;

                Different_list[0].transform.position = Vector3.right * 60 + Vector3.forward * 350;
                Different_list[1].transform.position = Vector3.right + Vector3.forward * 400;
                Different_list[2].transform.position = Vector3.right * -60 + Vector3.forward * 450;
            }
        }
    }

}
