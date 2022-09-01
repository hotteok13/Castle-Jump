using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;

    // ������Ʈ ��ü���� � pool�� ���� �ϴ��� �������ִ� �����Դϴ�.
    private IObjectPool<Bullet> lazerPool;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void SetPool(IObjectPool<Bullet> pool)
    {
        lazerPool = pool;
    }

    // ���� ������Ʈ�� �浹�� ���� �� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter(Collider other)
    {
        // �޸� Ǯ�� ��ȯ�Ǵ� �Լ�
        lazerPool.Release(this);
    }
}
