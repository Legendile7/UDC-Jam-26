using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenMan : MonoBehaviour
{
    private static FullscreenMan instance;
    bool fullscreen;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Toggle();
        }
    }

    void Toggle()
    {
        if (fullscreen)
        {
            Screen.fullScreen = false;
            fullscreen = false;
            Debug.Log("Fullscreen Off");
        }
        else
        {
            Screen.fullScreen = true;
            fullscreen = true;
            Debug.Log("Fullscreen On");
        }
    }

}
