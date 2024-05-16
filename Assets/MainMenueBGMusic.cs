using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenueBGMusic : MonoBehaviour
{
    public static MainMenueBGMusic instance;

    void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "MyScene")
        {
            Destroy(gameObject);
        }

        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "MyScene")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "MyScene")
        {
            Destroy(gameObject);
        }
    }
}
