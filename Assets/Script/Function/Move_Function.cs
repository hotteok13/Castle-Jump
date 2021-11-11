using UnityEngine;

public class Move_Function : MonoBehaviour
{
    void Update()
    {
        if (!GameManager.Game_Operation) return;

        transform.Translate(-transform.forward * GameManager.Speed / 2 * Time.deltaTime);

       if (transform.position.z <= -200)
       {
            Object_Pool.Queue_Pool.Insert_Queue(gameObject);
       }
        
    }
}
