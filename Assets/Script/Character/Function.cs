using UnityEngine;
using UnityEngine.UI;

public class Function : MonoBehaviour
{
    Color color;
    [SerializeField] Image sensor;
    [SerializeField] GameObject head_Light;
    int headlight_condition;

    private void Start()
    {
        color = sensor.GetComponent<Image>().color;
    }

    void Update()
    {      
        Sensor(GameManager.Sensor_Activation);
        Headlight(GameManager.Headlight_Activation);
    }

    void Sensor(bool Activation)
    {
        if (Activation)
        {
            var ray = new Ray(this.transform.position, this.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                color.r = 1;
                color.a = Random.Range(0.25f, 0.5f);
                sensor.GetComponent<Image>().color = color;

                Debug.Log(hit.collider.gameObject.name);
            }
            else
            {
                sensor.color = Color.clear;
            }
        }
    }

    void Headlight(bool Activation)
    {
        if(Activation)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                headlight_condition++;

                headlight_condition = headlight_condition == 1 ? 1 : 0;

                if (headlight_condition == 1)
                {
                    head_Light.SetActive(true);
                }
                else
                {
                    head_Light.SetActive(false);
                }
            }
        }
        else
        {
            head_Light.SetActive(false);
        }
    }

    
}
