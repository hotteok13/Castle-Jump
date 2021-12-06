using UnityEngine;
using UnityEngine.UI;

public class Speed_metor : MonoBehaviour
{
    [SerializeField] float speed_max;
    [SerializeField] float speed_min;
    [SerializeField] RectTransform Arrow;


    void Update()
    {
        Arrow.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(speed_min, speed_max, 0.5f));
    }
}
