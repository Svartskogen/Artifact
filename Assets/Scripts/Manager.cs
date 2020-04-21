using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public float timeToWin;
    public Artifact artifact;
    SceneManager sceneManager;
    float timer;
    // Start is called before the first frame update
    void Awake()
    {
        timer = timeToWin;
        sceneManager = GetComponent<SceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(artifact.health <= 0)
        {
            Lose();
        }

        if(timer <= 0)
        {
            Win();
        }
    }

    void Lose()
    {
        sceneManager.ChangeScene(3);
    }
    void Win()
    {
        sceneManager.ChangeScene(4);
    }
    public float GetTime()
    {
        return timer;
    }
}
