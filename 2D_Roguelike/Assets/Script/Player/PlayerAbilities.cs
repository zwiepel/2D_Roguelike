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
        if (Input.GetKeyDown(KeyCode.F)) // F�higkeit aktivieren
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
                Debug.Log("Keine F�higkeit vorhanden.");
                break;
        }
    }

    private IEnumerator ShadowDash()
    {
        Debug.Log("Shadow Dash aktiviert!");
        GetComponent<PlayerDodge>().dodgeCooldown = 0.5f; // K�rzere Abklingzeit
        yield return new WaitForSeconds(3f);
        GetComponent<PlayerDodge>().dodgeCooldown = 1f;
    }

    private void MadnessGaze()
    {
        Debug.Log("Wahnsinnsblick! Gegner werden verlangsamt.");
        // Hier k�nnte man die Gegner verlangsamen
    }

    private void DarkHealing()
    {
        Debug.Log("Dunkle Heilung! Spieler heilt 20 HP.");
        GetComponent<PlayerHealth>().Heal(20);
    }

    private void BloodMagic()
    {
        Debug.Log("Blutmagie! HP wird geopfert f�r Schaden.");
        GetComponent<PlayerHealth>().TakeDamage(10);
        // Angriffsst�rke k�nnte hier erh�ht werden
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
        // Hier k�nnte man Schwachstellen der Gegner markieren
    }
}
