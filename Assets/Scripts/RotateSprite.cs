using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateSprite : MonoBehaviour
{
    public float rotationSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the sprite around the Z-axis
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            PlayerPrefs.SetInt("Level" + nextScene, 1);
            SceneManager.LoadScene(nextScene);
        }
    }
}
