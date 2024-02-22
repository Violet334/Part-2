using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public float speed = 2;
    public List<Vector2> points;
    public float newPositionThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rb;
    public AnimationCurve contact;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        //set starting position
        transform.position = new Vector3(7, 2.5f, 0);
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if (points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rb.rotation = -angle;
        }
        rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0)
        {
            if (Vector2.Distance(transform.position, points[0]) < newPositionThreshold)
            {
                points.RemoveAt(0);
                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timer += 0.5f * Time.deltaTime;
        float interpolation = contact.Evaluate(timer);
        if (transform.localScale.x < 0.5f)
        {
            Destroy(gameObject);
        }
        transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
    }

    void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(lastPosition, newPosition) > newPositionThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }
    }
}
