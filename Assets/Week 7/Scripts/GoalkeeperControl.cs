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
        rb2 = GetComponent<Rigidbody2D>();
        rb.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rb.position = Vector3.Lerp(transform.position, rb2.position, 0.5f);
        Vector2 direction = rb2.position / transform.position;
        float degree = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        rb.rotation = -degree;
    }

}
