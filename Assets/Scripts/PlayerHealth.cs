using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public GameObject damageScreen;
    public GameObject deathScreen;
    [SerializeField] float damageScreenLifetime = 0.33f;
    public static bool alive = true;

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.value = currentHealth;
        alive = true;
    }

    public void TakeDamage(int damageAmount)
    {
        if (alive) {
            damageScreen.SetActive(true);
            Invoke("DamageScreenOff", damageScreenLifetime);
            currentHealth -= damageAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            healthSlider.value = currentHealth / 100f;

            if (currentHealth <= 0)
            {
                alive = false;
                deathScreen.SetActive(true);
                Invoke("ResetGame", 3f);
            }
        }
    }
    public void ResetGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void DamageScreenOff()
    {
        damageScreen.SetActive(false);
    }
}