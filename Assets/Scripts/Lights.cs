using UnityEngine;
using UnityEngine.UI;

public class Lights : MonoBehaviour
{
    public GameObject backgroundObject;
    public Button toggleButton;
    public Text buttonText;

    public UnityEngine.Color lightsOff;
    public UnityEngine.Color lightsOn1;

    public static bool lightsOn = true;

    public AudioClip toggleSFX;
    private AudioSource toggleSFXSc;

    private void Start()
    {
        toggleSFXSc = gameObject.AddComponent<AudioSource>();
        toggleSFXSc.clip = toggleSFX;
        toggleButton.onClick.AddListener(ToggleLightsState);
        UpdateButtonText();
        backgroundObject.GetComponent<Renderer>().material.color = lightsOn1;
        lightsOn = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleLightsState();
        }
    }

    private void ToggleLightsState()
    {
        if (PlayerHealth.alive)
        {
            toggleSFXSc.Play();
            lightsOn = !lightsOn;

            if (lightsOn)
            {
                backgroundObject.GetComponent<Renderer>().material.color = lightsOn1;
            }
            else
            {
                backgroundObject.GetComponent<Renderer>().material.color = lightsOff;
            }
        }
    }

    private void UpdateButtonText()
    {
        if (lightsOn)
        {
            buttonText.text = "Turn Lights Off";
        }
        else
        {
            buttonText.text = "Turn Lights On";
        }
    }
}
