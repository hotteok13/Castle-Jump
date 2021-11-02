using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Function : MonoBehaviour
{
    void Update()
    {
        if (!GameManager.Game_Operation) return;

        transform.Translate(-transform.forward * 100 * Time.deltaTime);

       if (transform.position.z <= -200)
       {
            Object_Pool.Queue_Pool.Insert_Queue(gameObject);
       }
        
    }
}
