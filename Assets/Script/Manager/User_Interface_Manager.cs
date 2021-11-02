using UnityEngine;
using UnityEngine.SceneManagement;

public class User_Interface_Manager : MonoBehaviour
{
    [SerializeField] GameObject Profile;
    [SerializeField] GameObject Setting;
    [SerializeField] GameObject Shop;
    [SerializeField] GameObject Mission;

    public void Play_Game()
     {
        Profile.SetActive(false);
        GameManager.Game_Operation = true;
    }

    public void Retry()
    {
        Character.Accident = false;
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     }

    public void Open(string open)
    {
        Sound_Manager.instance.SFX_Sound("Click");

        switch (open)
        {
            case "Setting":
                Setting.SetActive(true);
                break;
            case "Google":
                Application.OpenURL("https://play.google.com/store/apps/details?id=com.Default.SpaceCats");
                break;
            case "Shop":
                Shop.SetActive(true);
                break;
            case "Mission":
                Mission.SetActive(true);
                break;
        }
    }

    public void Close(string close)
    {
        switch (close)
        {
            case "Setting":
                Setting.SetActive(false);
                break;
            case "Shop":
                Shop.SetActive(false);
                break;
            case "Mission":
                Mission.SetActive(false);
                break;
        }
    }
}


