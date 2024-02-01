using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject plane;
    float Timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer >= 5)
        {
            Instantiate(plane);
            Timer = 0;
        }
        else
        {
            Timer += Random.Range(1 * Time.deltaTime, 5 * Time.deltaTime);
        }
    }
}
