using UnityEngine;
using UnityEngine.SceneManagement;

public class User_Interface_Manager : MonoBehaviour
{
    [SerializeField] GameObject Profile;
    [SerializeField] GameObject Setting;
    [SerializeField] GameObject Shop;
    [SerializeField] GameObject Mission;
    [SerializeField] GameObject Stage;

    public void Play_Game()
    {
        Time.timeScale = 1f;
        Profile.SetActive(false);    
    }

    public void Retry()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Next_Road()
    {
        GameManager.Road_Count++;
        GameManager.Arrival *= 2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Open(string open)
    {
        Sound_Manager.instance.SFX_Sound("Click");

        switch (open)
        {
            case "Setting":
                Open_Interface(true, false, false, false);
                break;
            case "Stage":
                Open_Interface(false, true, false, false);
                break;
            case "Shop":
                Open_Interface(false, false, true, false);
                break;
            case "Mission":
                Open_Interface(false, false, false, true);
                break;
        }
    }

    public void Open_Interface(bool setting, bool stage, bool shop, bool mission)
    {
        Setting.SetActive(setting);
        Stage.SetActive(stage);
        Shop.SetActive(shop);
        Mission.SetActive(mission);
    }

    public void Close(string close)
    {
        switch (close)
        {
            case "Setting":
                Setting.SetActive(false);
                break;
            case "Stage":
                Stage.SetActive(false);
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


