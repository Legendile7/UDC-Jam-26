using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManage : MonoBehaviour
{
    public GameObject PlayButton;
    public GameObject SettingsButton;
    public GameObject LevelSelect;
    public Button exitButton;
    public AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayButton.SetActive(true);
            SettingsButton.SetActive(true);
            LevelSelect.SetActive(false);
        }
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Play()
    {
        PlayButton.SetActive(false);
        SettingsButton.SetActive(false);
        LevelSelect.SetActive(true);
        exitButton.interactable = true;
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
        PlayButton.SetActive(true);
        SettingsButton.SetActive(true);
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
