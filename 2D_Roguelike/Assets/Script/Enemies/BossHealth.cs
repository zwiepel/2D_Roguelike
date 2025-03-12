using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    public bool hasSecondPhase = false;

    public GameObject healthBarPrefab;
    private Image healthBarFill;
    private GameObject healthBarInstance;

    private bool isInSecondPhase = false;

    private void Start()
    {
        currentHealth = maxHealth;

        healthBarInstance = Instantiate(healthBarPrefab, transform.position + Vector3.up * 3, Quaternion.identity, transform);
        healthBarFill = healthBarInstance.GetComponentInChildren<Image>();

        AdjustHealthBarSize();

        // Zufällig entscheiden, ob dieser Boss eine zweite Phase hat (50% Chance)
        if (!hasSecondPhase && Random.value > 0.5f)
        {
            hasSecondPhase = true;
        }
    }

    private void AdjustHealthBarSize()
    {
        float scaleFactor = Mathf.Clamp(maxHealth / 300f, 2f, 5f);
        healthBarInstance.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        UpdateHealthUI();

        if (currentHealth <= 0 && hasSecondPhase && !isInSecondPhase)
        {
            EnterSecondPhase();
        }
        else if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthUI()
    {
        healthBarFill.fillAmount = (float)currentHealth / maxHealth;
    }

    private void EnterSecondPhase()
    {
        isInSecondPhase = true;
        Debug.Log("Der Boss mutiert in seine zweite Phase! ⚠️");

        // Hier könnte man andere Werte setzen:
        maxHealth *= 2;
        currentHealth = maxHealth;
        healthBarFill.color = Color.red; // Setzt eine andere Farbe für die Lebensanzeige

        GetComponent<BossBehavior>().ActivateSecondPhase();
    }

    private void Die()
    {
        Destroy(healthBarInstance);
        Destroy(gameObject);
        Debug.Log("Boss besiegt!");
    }
}
