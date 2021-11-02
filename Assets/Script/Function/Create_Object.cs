using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Object : MonoBehaviour
{
    float time;

    private void Update()
    {
        time += Time.deltaTime;
        int A = Random.Range(1, 10);

        if (time >= A)
        {
            Create();
            time = 0.0f;
        }
    }

    void Create()
    {
        if (!GameManager.Game_Operation) return;

        int Rand = Random.Range(0,3);
        GameObject t_object = Object_Pool.Queue_Pool.Get_Queue();

        switch (Rand)
        {
            case 0:
                t_object.transform.position = new Vector3(-60, 0, 300);
                break;
            case 1:
                t_object.transform.position = new Vector3(0, 0, 300);
                break;
            case 2:
                t_object.transform.position = new Vector3(60, 0, 300);
                break;
        }
    }

}
