using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;

public class Game_Data
{
    public float time;
    public int Currency;
    public int kilometer;
    public bool Sensor_Gain;
    public bool Wiper_Gain;
    public bool Headlight_Gain;
}

public class GameManager : MonoBehaviour
{
    Game_Data data = new Game_Data();

    [SerializeField] Text Money;
    [SerializeField] Text Fuel_efficiency;
    [SerializeField] GameObject Stage_Window;
    [SerializeField] Button [] Purchase_Button;
    [SerializeField] GameObject Direction_Light;

    public static int Quest_Count = 0; 
    public static int Rate;
    public static int Speed = 200;
    public static int Arrival = 50;
    public static int Road_Count;
    public static bool Sensor_Activation;
    public static bool Headlight_Activation;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Speed = 200;
        Json_Load();

        Time.timeScale = 0f;

    }
    
    private void Update()
    {
        if (data.kilometer >= Arrival)
        {
            Stage_Window.SetActive(true);
            Time.timeScale = 0f;
        }

        data.time += Time.deltaTime;
        Night_and_Day();

        if (Speed >= 400)
        {
            Speed = 400;
        }

        if(Quest_Count == 2)
        {
            if (Speed >= 350)
            {
                Quest_Count++;
            }
        }

        Fuel_efficiency.text = data.kilometer.ToString() + " km/L";

        Money.text = data.Currency.ToString();
    }

    public void Night_and_Day()
    {
        if(data.time <= 30)
        {
            Direction_Light.SetActive(true);
        }
        else if(data.time >= 30)
        {
            Direction_Light.SetActive(false);
        }

        data.time = data.time > 60 ? 0 : data.time;
    }

    public void vehicle_Km()
    {
        Speed += 5; 
        data.kilometer++;
        data.Currency += 10;
    }

    public void Quest_Currecny(int Reward)
    {
        data.Currency += Reward;
    }

    public void Sensor_Purchase()
    {
        Quest_Count++;
        data.Currency -= 2000;
        Sensor_Activation = data.Sensor_Gain = true;
        Purchase_Button[0].gameObject.SetActive(false);
    }

    public void Wiper_Purchase()
    {
        data.Currency -= 3500;
        Purchase_Button[1].gameObject.SetActive(false);
    }

    public void Headlight_Purchase()
    {
        data.Currency -= 5000;
        Purchase_Button[2].gameObject.SetActive(false);
        Headlight_Activation = data.Headlight_Gain = true;
    }

    public void purchase_Active(int Sensor, int Wiper, int Headlight)
    {
        if (data.Currency < Sensor)
        {
            Purchase_Button[0].interactable = false;
        }
        else if(data.Currency >= Sensor)
        {
            Purchase_Button[0].interactable = true;
        }

        if (data.Currency < Wiper)
        {
            Purchase_Button[1].interactable = false;
        }
        else if (data.Currency >= Wiper)
        {
            Purchase_Button[1].interactable = true;
        }

        if (data.Currency < Headlight)
        {
            Purchase_Button[2].interactable = false;
        }
        else if (data.Currency >= Headlight)
        {
            Purchase_Button[2].interactable = true;
        }
    }

    public void Json_Save()
    {
        string json_data = JsonConvert.SerializeObject(data);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json_data);
        string format = System.Convert.ToBase64String(bytes);

        File.WriteAllText(Application.dataPath + "/NKStudio.josn", format);
    }

    public void Json_Load()
    {   
        string json_data = File.ReadAllText(Application.dataPath + "/NKStudio.josn");
        byte[] bytes = System.Convert.FromBase64String(json_data);
        string reformat = System.Text.Encoding.UTF8.GetString(bytes);

        data = JsonConvert.DeserializeObject<Game_Data>(reformat);
    }
}
