using UnityEngine;

[System.Serializable]
public class CharacterPreset
{
    public string characterName;
    public int maxHealth;
    public string abilityName;
    public string weaponName;
    public bool isUnlocked; // Gibt an, ob der Charakter freigeschaltet ist
}

public class PlayerCharacter : MonoBehaviour
{
    public CharacterPreset[] characterPresets;

    private int currentCharacterIndex = 0;
    private CharacterPreset activeCharacter;

    private void Start()
    {
        LoadCharacter(currentCharacterIndex);
    }

    public void LoadCharacter(int index)
    {
        if (index < 0 || index >= characterPresets.Length) return;

        if (!characterPresets[index].isUnlocked)
        {
            Debug.Log("Charakter ist noch nicht freigeschaltet!");
            return;
        }

        currentCharacterIndex = index;
        activeCharacter = characterPresets[index];

        Debug.Log($"Aktiver Charakter: {activeCharacter.characterName} | HP: {activeCharacter.maxHealth} | Fähigkeit: {activeCharacter.abilityName} | Waffe: {activeCharacter.weaponName}");
    }

    public CharacterPreset GetActiveCharacter()
    {
        return activeCharacter;
    }
    public void UnlockCharacter(int index)
    {
        if (index < 0 || index >= characterPresets.Length) return;

        if (!characterPresets[index].isUnlocked)
        {
            characterPresets[index].isUnlocked = true;
            Debug.Log($"{characterPresets[index].characterName} wurde freigeschaltet!");
        }
    }

}
