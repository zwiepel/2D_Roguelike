using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Image healthBarFill;
    private float damageReduction = 1f; // Standard 1 (keine Reduktion)

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        int reducedDamage = Mathf.RoundToInt(damage * damageReduction);
        currentHealth -= reducedDamage;

        if (currentHealth < 0)
            currentHealth = 0;

        Debug.Log($"Spieler nimmt {reducedDamage} Schaden! HP: {currentHealth}");
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        Debug.Log($"Spieler heilt sich um {amount}. HP: {currentHealth}");
        UpdateHealthUI();
    }

    public void SetDamageReduction(float factor)
    {
        damageReduction = factor;
        Debug.Log($"Schadensreduktion auf {damageReduction * 100}% gesetzt.");
    }

    private void UpdateHealthUI()
    {
        if (healthBarFill != null)
            healthBarFill.fillAmount = (float)currentHealth / maxHealth;
    }

    private void Die()
    {
        Debug.Log("Spieler ist gestorben!");
        // Hier könnte Game Over oder Respawn-Mechanik eingebaut werden
    }
}
