using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnvironment : MonoBehaviour
{
    public List<GameObject> columns;

    public GameObject column;

    void Start()
    {
        columns = new List<GameObject>();

        for (int i = 0; i < 50; i++)
        {
            columns.Add(Instantiate(column, new Vector3(Random.Range(-30f, 30f), Random.Range(-10f, -15f), Random.Range(-13f, 100f)), Quaternion.identity));
        }
    }
}

    
        

