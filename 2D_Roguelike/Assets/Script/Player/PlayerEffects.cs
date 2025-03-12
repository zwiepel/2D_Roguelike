using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    public GameObject soulShieldEffectPrefab; // Das Prefab für den Seelenschild-Effekt
    private GameObject activeEffect;

    public void ActivateSoulShield(float duration)
    {
        if (activeEffect != null) return; // Falls es schon aktiv ist, nichts tun

        activeEffect = Instantiate(soulShieldEffectPrefab, transform.position, Quaternion.identity, transform);
        Destroy(activeEffect, duration); // Nach X Sekunden verschwindet das Schild
    }
}
