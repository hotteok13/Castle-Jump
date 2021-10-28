using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class User_Interface_Manager : MonoBehaviour
{
    int Count;
    [SerializeField] GameObject Light;
    [SerializeField] GameObject Profile;
    [SerializeField] GameObject Setting;

    public void Play_Game()
     {
        Profile.SetActive(false);
        GameManager.Game_Operation = true;

        InvokeRepeating("Dinner", 10, 10);
    }

    void Dinner()
    {
        if (++Count % 2 == 0)
        {
            Light.SetActive(false);
        }
        else
        {
            Light.SetActive(true);
        }
    }

    public void Retry()
     {
        Character.Accident = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     }

    public void Open(string open)
    {
        switch (open)
        {
            case "Setting":
                Setting.SetActive(true);
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
        }

    }
}


