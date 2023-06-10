using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLevelDetector : MonoBehaviour
{
    public int levelCorrespondence;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Level1", 0) != 1)
        {
            PlayerPrefs.SetInt("Level1", 1);
        }
        Color col = GetComponent<Image>().color;
        if (PlayerPrefs.GetInt("Level" + levelCorrespondence, 0) != 1)
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
