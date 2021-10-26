using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Car_Select : MonoBehaviour
{
    [SerializeField] GameObject Car;

    private void Start()
    {       
        Prefab_Asset_Select();
    }

    public void Prefab_Asset_Select()
    {
        Car = Resources.Load<GameObject>("Surfer Van Cartoon Style");
        Instantiate(Car);
    }

}
