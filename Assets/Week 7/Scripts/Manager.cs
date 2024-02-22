using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Manager : MonoBehaviour
{
    public Slider charge;
    float chargeValue;
    public float maxCharge = 1;
    Vector2 direction;
    public static Player SelectedPlayer { get; private set; }
    public static void SetSelectedPlayer(Player player)
    {
        if(SelectedPlayer != null)
        {
            SelectedPlayer.Selected(false);
        }
        SelectedPlayer = player;
        SelectedPlayer.Selected(true);
    }

    private void FixedUpdate()
    {
        if(direction != Vector2.zero)
        {
            SelectedPlayer.Move(direction);
            direction = Vector2.zero;
            chargeValue = 0;
            charge.value = chargeValue;
        }
    }
    private void Update()
    {
        if (SelectedPlayer == null) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            chargeValue = 0;
            direction = Vector2.zero;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            chargeValue += Time.deltaTime;
            chargeValue = Mathf.Clamp(chargeValue, 0, maxCharge);
            charge.value = chargeValue;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)SelectedPlayer.transform.position).normalized * chargeValue;
        }
    }
}
