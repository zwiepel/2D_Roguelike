using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public enum EnemyType { Light, Medium, Heavy, Boss }
    public EnemyType enemyType;

    private int maxHealth;
    private int currentHealth;

    private void Start()
    {
        SetEnemyHealth();
        currentHealth = maxHealth;
    }

    private void SetEnemyHealth()
    {
        switch (enemyType)
        {
            case EnemyType.Light:
                maxHealth = 50;
                break;
            case EnemyType.Medium:
                maxHealth = 100;
                break;
            case EnemyType.Heavy:
                maxHealth = 200;
                break;
            case EnemyType.Boss:
                maxHealth = 1000;
                break;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        int soulReward = GetSoulReward();
        CurrencySystem.Instance.AddSouls(soulReward); // Nur Seelen, keine XP!

        CharacterUnlockSystem.Instance.AddKill(); // Zählt für Herausforderungen

        Destroy(gameObject);
    }


    private int GetSoulReward()
    {
        switch (enemyType)
        {
            case EnemyType.Light:
                return 10;
            case EnemyType.Medium:
                return 25;
            case EnemyType.Heavy:
                return 50;
            case EnemyType.Boss:
                return 200;
            default:
                return 0;
        }
    }
}
