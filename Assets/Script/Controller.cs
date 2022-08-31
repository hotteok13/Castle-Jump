using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] Transform centerMuzzle;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        InvokeRepeating(nameof(LayerCreate), 0, 0.1f);
    }

    void Update()
    {
        float x = Input.GetAxis("Mouse X");

        Vector3 direction = new Vector3( x, 0, 0);

        transform.Translate(direction.normalized * speed * Time.deltaTime);

        // 게임 오브젝트의 위치를 스크린 공간으로 변환합니다.
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);

        // 좌표 정보를 기준으로 조건문을 작성합니다.
        if (position.x < 0.1f) position.x = 0.1f;
        if (position.x > 0.9f) position.x = 0.9f;

        transform.position = Camera.main.ViewportToWorldPoint(position);
    }

    public void LayerCreate()
    {
        Instantiate
        (
            Resources.Load<GameObject>("Lazer"),
            centerMuzzle.position,
            Quaternion.identity
        );
    }

    
}
