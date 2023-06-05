using UnityEngine;
using UnityEngine.UI;

public class Lights : MonoBehaviour
{
    public GameObject backgroundObject;
    public Button toggleButton;
    public Text buttonText;

    public static bool lightsOn = true;

    private void Start()
    {
        toggleButton.onClick.AddListener(ToggleLightsState);
        UpdateButtonText();
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
            lightsOn = !lightsOn;

            if (lightsOn)
            {
                backgroundObject.GetComponent<Renderer>().material.color = Color.white;
            }
            else
            {
                backgroundObject.GetComponent<Renderer>().material.color = Color.black;
            }

            UpdateButtonText();
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
