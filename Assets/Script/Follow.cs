using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private GameObject character;

    void Start()
    {
        character = GameObject.Find("GameObject");
    }

    // Update is called once per frame
   // void Update()
   // {
   //     transform.position = Vector3.MoveTowards(transform.position,
    //        character.transform.position, 
   //         5 * Time.deltaTime);
   // }
}
