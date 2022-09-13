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

    // 이 함수를 버튼에 등록할 때 게임 오브젝트 매개 변수로 게임 오브젝트를 등록할 수 있습니다
    // 등록한 게임 오브젝트를 비활성화할 수 있습니다
    public void GameStart(GameObject mainMenu)
    {
        mainMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
