using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        //set starting position
        transform.position = new Vector3(7, 2.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {

    }
}
