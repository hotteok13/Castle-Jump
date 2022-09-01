using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer enemySprite;

    private Material enemyMaterial;
    [SerializeField] Material flash;

    private void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();

        enemyMaterial = enemySprite.material;

        flash = new Material(flash);
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime);

        if(transform.position.y <= -4.5f)
        {
            Destroy(gameObject);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(nameof(Damage));
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

    private IEnumerator Damage()
    {
        enemySprite.material = flash;
        flash.color = new Color(1, 1, 1, 0.5f);

        yield return new WaitForSeconds(0.05f);

        enemySprite.material = enemyMaterial;
    }
}
