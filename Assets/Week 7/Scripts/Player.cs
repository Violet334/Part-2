using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer player;
    public Color selected;
    public Color unselected;
    Rigidbody2D rb;
    public float speed = 1000;
    private void Start()
    {
        player = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Selected(false);
    }
    public void Selected(bool isSelected)
    {
        if (isSelected)
        {
            player.color = selected;
        }
        else
        {
            player.color = unselected;
        }
    }

    private void OnMouseDown()
    {
        Manager.SetSelectedPlayer(this);
    }

    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed);
    }
}
