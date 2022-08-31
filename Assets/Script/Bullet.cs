using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;

    void Update()
    {
        if(transform.position.y >= 6.5f) 
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    // 게임 오브젝트와 충돌을 했을 때 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
