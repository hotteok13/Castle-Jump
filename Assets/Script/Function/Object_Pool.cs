using System.Collections.Generic;
using UnityEngine;

public class Object_Pool : MonoBehaviour
{
    public static Object_Pool Queue_Pool;

    public GameObject [] Prefab = null;

    [SerializeField] Queue<GameObject> m_queue = new Queue<GameObject>();

    void Start()
    {
        Queue_Pool = this;

        for(int i = 0; i < 10; i++) // 10개의 객체를 미리 생성합니다.
        {
            GameObject t_object = Instantiate(Prefab[0], Vector3.zero, Quaternion.identity);
            m_queue.Enqueue(t_object);
            t_object.SetActive(false);

            GameObject t_object_one = Instantiate(Prefab[1], Vector3.zero, Quaternion.identity);
            m_queue.Enqueue(t_object_one);
            t_object_one.SetActive(false);
        }
    }

    public void Insert_Queue(GameObject p_object) // 사용한 객체를 pool에 반환하는 함수
    {
        m_queue.Enqueue(p_object);
        p_object.transform.position = Vector3.zero;
        p_object.SetActive(false);
    }

    public GameObject Get_Queue()
    {
        GameObject t_object = m_queue.Dequeue();
        t_object.SetActive(true);
        return t_object;
    }
}
