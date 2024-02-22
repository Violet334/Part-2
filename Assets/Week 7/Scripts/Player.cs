using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer player;
    public Color selected;
    public Color unselected;
    private void Start()
    {
        player = GetComponent<SpriteRenderer>();
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
}
