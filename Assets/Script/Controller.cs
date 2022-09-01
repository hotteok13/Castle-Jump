using UnityEngine;
using UnityEngine.Pool;

public class Controller : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] Transform centerMuzzle;

    // �޸� Ǯ�� ����� ���� ������Ʈ
    [SerializeField] Bullet lazerPrefab;

    // �޸� Ǯ�� ����� Ŭ����
    private IObjectPool<Bullet> lazerPool;

    private void Awake()
    {
        // 1. ���� ������Ʈ�� �����ϴ� �Լ�
        // 2. ���� ������Ʈ�� Ȱ��ȭ�ϴ� �Լ�
        // 3. ���� ������Ʈ�� ��Ȱ��ȭ�ϴ� �Լ�
        // 4. ���� ������Ʈ�� �ı��ϴ� �Լ�
        // 5. maxSize �޸𸮿� �����ϰ� ���� ����
        lazerPool = new ObjectPool<Bullet>
        (
             LazerCreate,
             LazerGet,
             ReleaseLazer,
             DestroyLazer,
             maxSize : 20
        );
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        InvokeRepeating(nameof(InfiniteLazer), 0, 0.1f);
    }

    public void InfiniteLazer()
    {
        var bullet = lazerPool.Get();
        bullet.transform.position = centerMuzzle.transform.position;
    }

    void Update()
    {
        float x = Input.GetAxis("Mouse X");

        Vector3 direction = new Vector3( x, 0, 0);

        transform.Translate(direction.normalized * speed * Time.deltaTime);

        // ���� ������Ʈ�� ��ġ�� ��ũ�� �������� ��ȯ�մϴ�.
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);

        // ��ǥ ������ �������� ���ǹ��� �ۼ��մϴ�.
        if (position.x < 0.1f) position.x = 0.1f;
        if (position.x > 0.9f) position.x = 0.9f;

        transform.position = Camera.main.ViewportToWorldPoint(position);
    }

    // ���� ������Ʈ�� �����ϴ� �Լ�
    public Bullet LazerCreate()
    {
        Bullet bullet = Instantiate(lazerPrefab).GetComponent<Bullet>();
        bullet.SetPool(lazerPool);
        return bullet;
    }

    // Get�� ����� �� ����Ǵ� �Լ�
    // ���� ������Ʈ�� Ȱ��ȭ�ϴ� �Լ�
    public void LazerGet(Bullet lazer)
    {
        lazer.gameObject.SetActive(true);
    }

    // ���� ������Ʈ�� ��Ȱ��ȭ�ϴ� �Լ�
    public void ReleaseLazer(Bullet lazer)
    {
        lazer.gameObject.SetActive(false);
    }

    // ���� ������Ʈ�� �ı��ϴ� �Լ�
    public void DestroyLazer(Bullet lazer)
    {
        Destroy(lazer.gameObject);
    }

}
