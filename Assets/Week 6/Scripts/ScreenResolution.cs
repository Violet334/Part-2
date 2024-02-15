using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolution : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetScreenResolutionFull()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void SetScreenResolutionSmall()
    {
        Screen.SetResolution(1280, 720, true);
    }
}
