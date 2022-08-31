using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime);

        if(transform.position.y <= -4.5f)
        {
            Destroy(gameObject);
        }
    }

    // ���� ������Ʈ�� �浹�� ���� �� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    // ���� ������Ʈ�� �ı��Ǿ��� �� ȣ��Ǵ� �Լ�
    private void OnDestroy()
    {
            Instantiate
            (
               Resources.Load<GameObject>("Explosion"), // �����ϰ� ���� ���� ������Ʈ
               transform.position, // �����Ǵ� ���� ������Ʈ�� ��ġ 
               Quaternion.identity // Quaternion.identity : ȸ���� ���� �ʰڴٴ� �ǹ��Դϴ�.
            );
    }
}
