using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;

public class Game_Data
{
    public int Currency;
    public int kilometer;
}


public class GameManager : MonoBehaviour
{
    Game_Data data = new Game_Data();

    [SerializeField] Text Money;
    [SerializeField] Text Fuel_efficiency;
    [SerializeField] GameObject Stage_Window;
    [SerializeField] Button [] Purchase_Button;
    [SerializeField] GameObject Fuel_efficiency_Record;

    public static int Rate;
    public static int Speed = 200;
    public static int Arrival = 50;
    public static int Road_Count;
    public static bool Sensor_Activation;

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

        if (Speed >= 400)
        {
            Speed = 400;
        }

        Fuel_efficiency_Record.SetActive(true);
        Fuel_efficiency.text = data.kilometer.ToString() + " km/L";

        Money.text = data.Currency.ToString();
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

    public void Purchase_System(int purchase)
    {
        data.Currency -= purchase;      
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
