using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMove : MonoBehaviour
{
    public void Scene(string name)
    {
        Loading.LoadScene(name);
    }
}
