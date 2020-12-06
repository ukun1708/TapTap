using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnvironment : MonoBehaviour
{
    public List<GameObject> columns;

    public GameObject column;

    public static CreateEnvironment Singleton;

    void Start()
    {
        Singleton = this;
    }
}

    
        

