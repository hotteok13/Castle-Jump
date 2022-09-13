using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text score;

    void Start()
    {
        
    }

    void Update()
    {
        score.text = "Kill : " + GameManager.instance.score;
    }

    // �� �Լ��� ��ư�� ����� �� ���� ������Ʈ �Ű� ������ ���� ������Ʈ�� ����� �� �ֽ��ϴ�
    // ����� ���� ������Ʈ�� ��Ȱ��ȭ�� �� �ֽ��ϴ�
    public void GameStart(GameObject mainMenu)
    {
        mainMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}