using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D rb2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, rb2.position);
    }

}
