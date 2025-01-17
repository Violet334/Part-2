using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Plane : MonoBehaviour
{
    public float playerScore = 0;
    bool landed = false;
    public Collider2D runway;

    public List<Sprite> planes;
    SpriteRenderer spriteRenderer;

    public List<Vector2> points;
    public float newPositionThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    float speed;
    Rigidbody2D rigidbody;
    public AnimationCurve landing;
    float landingTimer;

    private void Start()
    {
        runway = GetComponent<Collider2D>();

        transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
        transform.rotation = Quaternion.Euler(0,0,Random.Range(0, 360));
        speed = Random.Range(1, 3);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = planes[Random.Range(0, 4)];
        spriteRenderer.color = Color.white;

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
            currentPosition = transform.position;
        if(points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }
        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void Update()
    {
        Collider2D plane = Physics2D.OverlapPoint(transform.position);
        if (plane == runway)
        {
            landed = true;
        }
        else
        {
            landed = false;
        }
        if (landed = true)
        {
            playerScore += 1;
            landingTimer += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }

            /*if(Input.GetKey(KeyCode.Space))
            {
                landingTimer += 0.5f * Time.deltaTime;
                float interpolation = landing.Evaluate(landingTimer);
                if (transform.localScale.z < 0.1f)
                {
                    Destroy(gameObject);
                }
                transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
            }*/
            lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0 )
        {
            if(Vector2.Distance(transform.position, points[0]) < newPositionThreshold)
            {
                points.RemoveAt(0);
                for(int i = 0; i < lineRenderer.positionCount -2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        spriteRenderer.color = Color.red;
        if (Vector3.Distance(transform.position, collision.transform.position) < 0.08)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(lastPosition, newPosition) > newPositionThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }
    }
}
