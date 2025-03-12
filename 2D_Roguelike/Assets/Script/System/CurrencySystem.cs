using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    public static CurrencySystem Instance;

    [SerializeField] private int totalSouls = 0; // Seelen für Upgrades und Shop
    [SerializeField] private int totalXP = 0;    // XP für Charakter-Freischaltung

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

    // Seelen hinzufügen
    public void AddSouls(int amount)
    {
        totalSouls += amount;
        Debug.Log($"Seelen gesammelt: {amount} | Gesamtseelen: {totalSouls}");
    }

    // XP hinzufügen
    public void AddXP(int amount)
    {
        totalXP += amount;
        Debug.Log($"XP gesammelt: {amount} | Gesamt-XP: {totalXP}");

        // Falls das Charakter-Freischalt-System existiert, informieren
        if (CharacterUnlockSystem.Instance != null)
        {
            CharacterUnlockSystem.Instance.AddCurrency(amount);
        }
    }

    // Seelen ausgeben (z. B. für Shops)
    public bool SpendSouls(int amount)
    {
        if (totalSouls >= amount)
        {
            totalSouls -= amount;
            Debug.Log($"{amount} Seelen ausgegeben. Verbleibende Seelen: {totalSouls}");
            return true;
        }
        Debug.Log("Nicht genug Seelen!");
        return false;
    }

    // XP ausgeben (z. B. für Charakter-Freischaltung)
    public bool SpendXP(int amount)
    {
        if (totalXP >= amount)
        {
            totalXP -= amount;
            Debug.Log($"{amount} XP ausgegeben. Verbleibende XP: {totalXP}");
            return true;
        }
        Debug.Log("Nicht genug XP!");
        return false;
    }

    public int GetTotalSouls()
    {
        return totalSouls;
    }

    public int GetTotalXP()
    {
        return totalXP;
    }
}
