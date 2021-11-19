﻿using UnityEngine;

public class Character : MonoBehaviour
{
    int Line = 1; // 0 : Left, 1 : Middle, 2 : Right
    [SerializeField] float Line_Distance; // 두 선 사이의 거리
    [SerializeField] GameObject Traffic_Accident;

    void Update()
    {
        if (!GameManager.Game_Operation) return;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (++Line == 3)
                Line = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (--Line == -1)
                Line = 0;
        }

        Vector3 Position = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(Line == 0)
        {
            Position += Vector3.left * Line_Distance;
        }
        else if(Line == 2)
        {
            Position += Vector3.right * Line_Distance;
        }

        transform.position = Vector3.Lerp(transform.position, Position, 10f * Time.deltaTime);    
    }

    private void OnTriggerEnter(Collider other)
    {
        string material_Name = other.transform.GetComponent<BoxCollider>().material.name;

        if(material_Name == "Dodge (Instance)")
        {
            Traffic_Accident.SetActive(true);
            GameManager.Game_Operation = false;
            Sound_Manager.instance.SFX_Sound("Collision");
        }    
    }
}
