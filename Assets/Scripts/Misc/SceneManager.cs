using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple Scene Manager with public non-static methods for UI usage 
/// </summary>
public class SceneManager : MonoBehaviour
{ 
    public void ChangeScene(int id)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(id, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
    public void ChangeScene(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
