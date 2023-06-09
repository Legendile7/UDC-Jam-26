using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
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
}
