using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject enemy;
    private void Start()
    {
        for (int i = 0; i < 10; i++)
            Instantiate(enemy, GetRandomPosition(), Quaternion.identity);
    }

    public Vector3 GetRandomPosition()
    {
        // 게임 오브젝트를 중심으로 기준 반지름 50인 원을 설정합니다.
        float radius = 50f;

        // 첫 번째로 x값을 계산합니다.
        // 원점을 기준으로 -50, 50사이의 난수 값을 생성합니다.
        float x = Random.Range(-radius, radius);
                         
        // 방정식 
        float z = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(x, 2));

        // 랜덤으로 0과 1사이의 난수값을 생성하고 0이 나오면 음수 형태의 temporaryZ을 temporaryZ 변수에 넣어줍니다.
        if (Random.Range(0, 2) == 0)
        {
            z = -z;
        }

        return new Vector3(x, 0, z);
    }
}
