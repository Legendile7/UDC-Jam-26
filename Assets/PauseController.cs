using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseWindow;
    public KeyCode pauseKeybind;
    bool paused;
    AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        pauseWindow.SetActive(false);
        paused = false;
        click = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseKeybind))
            PauseToggle();
    }

    public void PauseToggle()
    {
        if (paused)
        {
            Time.timeScale = 1f;
            paused = false;
            click.Play();
            pauseWindow.SetActive(false);
        }
        else
        {
            paused = true;
            click.Play();
            pauseWindow.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Menu()
    {
        PauseToggle();
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        PauseToggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
