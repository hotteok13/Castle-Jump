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

    // ���� ������Ʈ�� �浹�� ���� �� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
