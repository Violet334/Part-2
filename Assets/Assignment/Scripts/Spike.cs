using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 speed;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = new Vector2(Random.Range(1, 3), Random.Range(-2, 1));
        transform.position = new Vector2(-11, Random.Range(-4, 4));
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("hurt", SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}