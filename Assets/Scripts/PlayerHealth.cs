using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public GameObject damageScreen;
    public GameObject healScreen;
    public GameObject deathScreen;
    [SerializeField] float damageScreenLifetime = 0.33f;
    [SerializeField] float healScreenLifetime = 0.33f;
    public static bool alive = true;

    private CameraShake mainCam;

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.value = currentHealth;
        alive = true;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
    }

    public void TakeDamage(int damageAmount)
    {
        if (alive) {
            damageScreen.SetActive(true);
            Invoke("DamageScreenOff", damageScreenLifetime);
            currentHealth -= damageAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            healthSlider.value = currentHealth / 100f;

            mainCam.shakeIntensity = damageAmount/100f;

            if (currentHealth <= 0)
            {
                alive = false;
                deathScreen.SetActive(true);
                Invoke("ResetGame", 3f);
            }

            mainCam.Shake();
        }
    }

    public void Heal(int amount)
    {
        if (alive)
        {
            healScreen.SetActive(true);
            Invoke("HealScreenOff", healScreenLifetime);
            currentHealth += amount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            healthSlider.value = currentHealth / 100f;
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
    void HealScreenOff()
    {
        healScreen.SetActive(false);
    }
}