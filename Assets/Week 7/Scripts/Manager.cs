using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Manager : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
