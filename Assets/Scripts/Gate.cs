using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool needsElectricity = true;
    public bool animated;
    private bool isEnabled;

    GameObject player;

    void Start()
    {
        if (needsElectricity && Lights.lightsOn || !needsElectricity)
        {
            isEnabled = true;
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (needsElectricity && Lights.lightsOn)
        {
            if (!isEnabled && animated)
            {
                Animate(true);
            }
            isEnabled = true;
        }
        else if (needsElectricity && !Lights.lightsOn)
        {
            if (isEnabled && animated)
            {
                Animate(false);
            }
            isEnabled = false;
        }
    }

    void Animate(bool condition)
    {
        Animator a = GetComponent<Animator>();
        if (condition)
        {
            a.SetTrigger("On");
        }
        else
        {
            a.SetTrigger("Off");
        }
    }
}
