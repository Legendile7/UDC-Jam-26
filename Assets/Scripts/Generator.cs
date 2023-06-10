using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Animator animator;
    public bool alwaysActive = false;
    public GameObject connected;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (alwaysActive)
        {
            animator.SetBool("generatorOn", true);
            if (connected.GetComponent<HorizontalPlatform>() != null)
            {
                connected.GetComponent<HorizontalPlatform>().generatorOn = true;
            }
            else if (connected.GetComponent<Teleporter>() != null)
            {
                connected.GetComponent<Teleporter>().generatorOn = true;
            }
            else if (connected.GetComponent<LaserBeam>() != null)
            {
                connected.GetComponent<LaserBeam>().generatorOn = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            animator.SetBool("generatorOn", true);
            if (connected.GetComponent<HorizontalPlatform>() != null)
            {
                connected.GetComponent<HorizontalPlatform>().generatorOn = true;
            }
            else if (connected.GetComponent<Teleporter>() != null)
            {
                connected.GetComponent<Teleporter>().generatorOn = true;
            }
            else if (connected.GetComponent<LaserBeam>() != null)
            {
                connected.GetComponent<LaserBeam>().generatorOn = true;
            }
        }
    }
}
