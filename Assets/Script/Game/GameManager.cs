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
    [SerializeField] GameObject Traffic_Accident;
    [SerializeField] GameObject Fuel_efficiency_Record;

    public static int Rate;
    public static int Speed = 200;
    public static int Arrival = 50;
    public static int Road_Count;
    public static bool Game_Operation;
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Speed = 200;
        Json_Load();
    }
    
    private void Update()
    {
        if (Game_Operation)
        {
            if (data.kilometer >= Arrival)
            {
                Road_Count++;
                Game_Operation = false;
                Stage_Window.SetActive(true);
            }

            Fuel_efficiency_Record.SetActive(true);
            Fuel_efficiency.text = data.kilometer.ToString() + " km/L";

            Traffic_Accident.SetActive(false);
        }
        else
        {
            if (Character.Accident)
            {
                Traffic_Accident.SetActive(true);
            }

            Money.text = data.Currency.ToString();
            Fuel_efficiency_Record.SetActive(false);
        }
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
