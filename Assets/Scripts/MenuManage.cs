using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManage : MonoBehaviour
{
    public GameObject PlayButton;
    public GameObject ControlsButton;
    public GameObject LevelSelect;
    public GameObject controlsWindow;
    public Button exitButton;
    public Button exitButton2;
    public AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayButton.SetActive(true);
            ControlsButton.SetActive(true);
            LevelSelect.SetActive(false);
            controlsWindow.SetActive(false);
        }
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Play()
    {
        PlayButton.SetActive(false);
        ControlsButton.SetActive(false);
        LevelSelect.SetActive(true);
        controlsWindow.SetActive(false);
        exitButton.interactable = true;
        exitButton2.interactable = false;
    }
    public void ResetPlay()
    {
        exitButton.interactable = false;
        LevelSelect.GetComponent<Animator>().SetTrigger("Off");
        Invoke("OffLevel", 0.35f);
    }
    void OffLevel()
    {
        LevelSelect.SetActive(false);
        controlsWindow.SetActive(false);
        PlayButton.SetActive(true);
        ControlsButton.SetActive(true);
    }
    public void Controls()
    {
        PlayButton.SetActive(false);
        ControlsButton.SetActive(false);
        LevelSelect.SetActive(false);
        controlsWindow.SetActive(true);
        exitButton.interactable = false;
        exitButton2.interactable = true;
    }
    public void ResetControls()
    {
        exitButton2.interactable = false;
        controlsWindow.GetComponent<Animator>().SetTrigger("Off");
        Invoke("OffLevel", 0.35f);
    }
    public void Click()
    {
        if (click != null)
        {
            click.Play();
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
