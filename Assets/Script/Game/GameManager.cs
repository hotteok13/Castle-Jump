using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;

class Game_Data
{
    public int kilometer;

    public Game_Data(int current_kilometer)
    {
        kilometer = current_kilometer;
    }
}

public class GameManager : MonoBehaviour
{
    Game_Data data = new Game_Data(1);

    [SerializeField] Text Fuel_efficiency, kilometer;
    [SerializeField] GameObject Traffic_Accident;
    [SerializeField] GameObject Fuel_efficiency_Record;
 
    public static bool Game_Operation;
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Json_Load();
    }
    

    private void Update()
    {
        if (Game_Operation)
        {
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

            Fuel_efficiency_Record.SetActive(false);
        }

        kilometer.text = data.kilometer.ToString() + " / 100 ";
    }

    public void vehicle_Km()
    {
        data.kilometer++;
    }


    public void Json_Save()
    {
        string json_data = JsonConvert.SerializeObject(data);
        File.WriteAllText(Application.dataPath + "/NKStudio.josn",json_data);
    }

    public void Json_Load()
    {
        string json_data = File.ReadAllText(Application.dataPath + "/NKStudio.josn");
        data = JsonConvert.DeserializeObject<Game_Data>(json_data);
    }
}
