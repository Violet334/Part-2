using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    // Spawn arrow
    public GameObject arrow;
    public void Spawn()
    {
        Instantiate(arrow);
    }
}
