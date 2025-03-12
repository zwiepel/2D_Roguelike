using UnityEngine;

public class CharacterUnlockSystem : MonoBehaviour
{
    public static CharacterUnlockSystem Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private int enemiesKilled = 0;
    private int currencyCollected = 0;

    public int enemiesNeededForUnlock = 50;
    public int currencyNeededForUnlock = 1000;

    // Hier die fehlenden XP-Kosten hinzufügen:
    public int xpCostCharacter4 = 1500;
    public int xpCostCharacter5 = 2000;
    public int xpCostCharacter6 = 3000;

    public void AddKill()
    {
        enemiesKilled++;
        CheckUnlocks();
    }

    public void AddCurrency(int amount)
    {
        currencyCollected += amount;
        CheckUnlocks();
    }

    public bool UnlockCharacterWithXP(int characterIndex, int cost)
    {
        if (CurrencySystem.Instance.SpendXP(cost))
        {
            FindFirstObjectByType<PlayerCharacter>().UnlockCharacter(1);
            return true;
        }
        return false;
    }

    private void CheckUnlocks()
    {
        if (enemiesKilled >= enemiesNeededForUnlock)
        {
            FindFirstObjectByType<PlayerCharacter>().UnlockCharacter(1);
            Debug.Log("Charakter durch Gegner-Kills freigeschaltet!");
        }

        if (currencyCollected >= currencyNeededForUnlock)
        {
            FindFirstObjectByType<PlayerCharacter>().UnlockCharacter(1);
            Debug.Log("Charakter durch XP freigeschaltet!");
        }
    }
}
