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

    private void Start()
    {
        toggleButton.onClick.AddListener(ToggleLightsState);
        UpdateButtonText();
        string hexCode = "#3F3F3F";
        ColorUtility.TryParseHtmlString(hexCode, out lightsOff);
        string hexCode2 = "#FFFFFF";
        ColorUtility.TryParseHtmlString(hexCode2, out lightsOn1);
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
