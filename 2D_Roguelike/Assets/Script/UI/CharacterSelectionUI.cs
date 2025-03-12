using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionUI : MonoBehaviour
{
    public CharacterUnlockSystem unlockSystem;

    public Button buyCharacter4Button;
    public Button buyCharacter5Button;
    public Button buyCharacter6Button;

    private void Start()
    {
        buyCharacter4Button.onClick.AddListener(() => TryUnlock(3, unlockSystem.xpCostCharacter4));
        buyCharacter5Button.onClick.AddListener(() => TryUnlock(4, unlockSystem.xpCostCharacter5));
        buyCharacter6Button.onClick.AddListener(() => TryUnlock(5, unlockSystem.xpCostCharacter6));
    }

    private void TryUnlock(int characterIndex, int cost)
    {
        if (unlockSystem.UnlockCharacterWithXP(characterIndex, cost))
        {
            Debug.Log($"Charakter {characterIndex + 1} gekauft!");
        }
        else
        {
            Debug.Log("Nicht genug XP!");
        }
    }
}
