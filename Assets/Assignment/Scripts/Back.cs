using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public void LoadBackScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int lastSceneIndex = (currentSceneIndex - 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(lastSceneIndex);
    }
}
