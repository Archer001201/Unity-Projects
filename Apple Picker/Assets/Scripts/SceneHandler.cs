using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [Header("Set in Inspector")] public string nextSceneName;

    public void GoToScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
