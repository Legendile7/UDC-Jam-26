using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Intensity of the camera shake
    public float shakeIntensity = 0.1f;

    // Duration of the camera shake
    public float shakeDuration = 0.5f;

    // Reference to the main camera
    private Camera mainCamera;

    // Initial position of the camera
    private Vector3 initialPosition;

    private void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        initialPosition = mainCamera.transform.localPosition;
    }

    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            // Generate a random offset within a unit circle
            float offsetX = Random.Range(-1f, 1f) * shakeIntensity;
            float offsetY = Random.Range(-1f, 1f) * shakeIntensity;

            // Apply the offset to the camera position
            mainCamera.transform.localPosition = new Vector3(initialPosition.x + offsetX, initialPosition.y + offsetY, initialPosition.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Reset the camera position
        mainCamera.transform.localPosition = initialPosition;
    }
}
