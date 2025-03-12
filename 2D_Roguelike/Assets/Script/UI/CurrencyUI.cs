using UnityEngine;
using UnityEngine.UI;

public class CurrencyDisplayUI : MonoBehaviour // Neuer Name
{
    public Text soulText;
    public Text xpText;

    private void Update()
    {
        if (CurrencySystem.Instance != null)
        {
            soulText.text = $"Seelen: {CurrencySystem.Instance.GetTotalSouls()}";
            xpText.text = $"XP: {CurrencySystem.Instance.GetTotalXP()}";
        }
    }
}
