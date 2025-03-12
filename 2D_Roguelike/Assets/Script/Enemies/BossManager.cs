using UnityEngine;

public class BossManager : MonoBehaviour
{
    public GameObject[] world1Bosses;
    public GameObject[] world2Bosses;
    public GameObject[] world3Bosses;
    public GameObject[] world4Bosses; // Letzte Welt mit garantiert zwei Phasen

    private GameObject activeBoss;

    public void SpawnBoss(int world)
    {
        GameObject bossPrefab = null;

        switch (world)
        {
            case 1:
                bossPrefab = world1Bosses[Random.Range(0, world1Bosses.Length)];
                break;
            case 2:
                bossPrefab = world2Bosses[Random.Range(0, world2Bosses.Length)];
                break;
            case 3:
                bossPrefab = world3Bosses[Random.Range(0, world3Bosses.Length)];
                break;
            case 4:
                bossPrefab = world4Bosses[Random.Range(0, world4Bosses.Length)];
                break;
        }

        if (bossPrefab != null)
        {
            activeBoss = Instantiate(bossPrefab, transform.position, Quaternion.identity);
        }
    }
}
