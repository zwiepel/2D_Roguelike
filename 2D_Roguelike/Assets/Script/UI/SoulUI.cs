using UnityEngine;
using UnityEngine.UI;

public class CurrencyUI : MonoBehaviour
{
    public Text soulText;
    private CurrencySystem currencySystem;

    private void Start()
    {
        currencySystem = FindFirstObjectByType<CurrencySystem>();
        UpdateSoulUI();
    }

    private void Update()
    {
        UpdateSoulUI();
    }

    private void UpdateSoulUI()
    {
        soulText.text = $"Seelen: {currencySystem.GetTotalSouls()}";
    }
}
