using UnityEngine;
using UnityEngine.UI;

public class Function : MonoBehaviour
{
    [SerializeField] Image sensor;
    Color color;

    private void Start()
    {
        color = sensor.GetComponent<Image>().color;
    }

    void Update()
    {      
        Sensor(GameManager.Sensor_Activation);
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

    
}
