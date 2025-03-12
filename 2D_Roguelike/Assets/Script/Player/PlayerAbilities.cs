using UnityEngine;
using System.Collections;

public class PlayerAbilities : MonoBehaviour
{
    private PlayerCharacter playerCharacter;
    private CharacterPreset activeCharacter;

    private void Start()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
        activeCharacter = playerCharacter.GetActiveCharacter();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Fähigkeit aktivieren
        {
            ActivateAbility();
        }
    }

    private void ActivateAbility()
    {
        switch (activeCharacter.abilityName)
        {
            case "Shadow Dash":
                StartCoroutine(ShadowDash());
                break;
            case "Wahnsinnsblick":
                MadnessGaze();
                break;
            case "Dunkle Heilung":
                DarkHealing();
                break;
            case "Blutmagie":
                BloodMagic();
                break;
            case "Seelenschild":
                StartCoroutine(SoulShield());
                break;
            case "Prophetische Vision":
                PropheticVision();
                break;
            default:
                Debug.Log("Keine Fähigkeit vorhanden.");
                break;
        }
    }

    private IEnumerator ShadowDash()
    {
        Debug.Log("Shadow Dash aktiviert!");
        GetComponent<PlayerDodge>().dodgeCooldown = 0.5f; // Kürzere Abklingzeit
        yield return new WaitForSeconds(3f);
        GetComponent<PlayerDodge>().dodgeCooldown = 1f;
    }

    private void MadnessGaze()
    {
        Debug.Log("Wahnsinnsblick! Gegner werden verlangsamt.");
        // Hier könnte man die Gegner verlangsamen
    }

    private void DarkHealing()
    {
        Debug.Log("Dunkle Heilung! Spieler heilt 20 HP.");
        GetComponent<PlayerHealth>().Heal(20);
    }

    private void BloodMagic()
    {
        Debug.Log("Blutmagie! HP wird geopfert für Schaden.");
        GetComponent<PlayerHealth>().TakeDamage(10);
        // Angriffsstärke könnte hier erhöht werden
    }

    private IEnumerator SoulShield()
    {
        Debug.Log("Seelenschild aktiviert! 50% weniger Schaden.");
        GetComponent<PlayerHealth>().SetDamageReduction(0.5f);
        yield return new WaitForSeconds(3f);
        GetComponent<PlayerHealth>().SetDamageReduction(1f);
    }

    private void PropheticVision()
    {
        Debug.Log("Prophetische Vision! Schwachpunkte der Gegner sichtbar.");
        // Hier könnte man Schwachstellen der Gegner markieren
    }
}
