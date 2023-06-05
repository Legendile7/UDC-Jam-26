using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public RectTransform healthBar;
    private float initialHealthBarWidth;

    private void Start()
    {
        currentHealth = maxHealth;
        initialHealthBarWidth = healthBar.sizeDelta.x;
        UpdateHealthBar();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            ResetGame();
        }
    }

    private void UpdateHealthBar()
    {
        float healthRatio = (float)currentHealth / maxHealth;
        float newWidth = initialHealthBarWidth * healthRatio;
        healthBar.anchorMin = new Vector2(0, healthBar.anchorMin.y);
        healthBar.anchorMax = new Vector2(0, healthBar.anchorMax.y);
        healthBar.pivot = new Vector2(0, healthBar.pivot.y);
        healthBar.anchoredPosition = new Vector2(20, healthBar.anchoredPosition.y);
        healthBar.sizeDelta = new Vector2(newWidth - 1, healthBar.sizeDelta.y);
    }

    public void ResetGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}