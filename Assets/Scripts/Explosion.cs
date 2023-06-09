using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosion : MonoBehaviour
{
    private void OnEnable()
    {
        PlayParticleSystemsInChildren(transform);
        Invoke("ResetGame", 3f);
    }
    public static void PlayParticleSystemsInChildren(Transform parent)
    {
        // Loop through all child objects
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);

            // Check if the child has a ParticleSystem component
            ParticleSystem particleSystem = child.GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                // Play the particle system
                particleSystem.Play();
            }

            // Recursive call to check child's children
            PlayParticleSystemsInChildren(child);
        }
    }

    public void ResetGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
