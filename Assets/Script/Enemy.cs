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

    // 게임 오브젝트와 충돌을 했을 때 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    // 게임 오브젝트가 파괴되었을 때 호출되는 함수
    private void OnDestroy()
    {
            Instantiate
            (
               Resources.Load<GameObject>("Explosion"), // 생성하고 싶은 게임 오브젝트
               transform.position, // 생성되는 게임 오브젝트의 위치 
               Quaternion.identity // Quaternion.identity : 회전을 하지 않겠다는 의미입니다.
            );
    }
}
