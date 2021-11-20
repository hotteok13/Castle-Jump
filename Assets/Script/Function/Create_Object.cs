using UnityEngine;

public class Create_Object : MonoBehaviour
{
    float time;

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= Random.Range(1, GameManager.Rate))
        {
            Create();
            time = 0.0f;
        }
    }

    void Create()
    {
        int Rand = Random.Range(0,3);
        GameObject t_object = Object_Pool.Queue_Pool.Get_Queue();

        switch (Rand)
        {
            case 0:
                t_object.transform.position = new Vector3(-60, 0, 350);
                break;
            case 1:
                t_object.transform.position = new Vector3(0, 0, 350);
                break;
            case 2:
                t_object.transform.position = new Vector3(60, 0, 350);
                break;
        }
    }

}
