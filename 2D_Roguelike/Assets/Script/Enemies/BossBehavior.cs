using UnityEngine;
using System.Collections;

public class BossBehavior : MonoBehaviour
{
    public enum BossType { TheAberration, TheLurker, TheFleshMonstrosity, TheAncientOne }
    public BossType bossType;

    public float attackCooldown = 3f;
    private bool isAttacking = false;
    private bool isSecondPhase = false;

    private Transform player;
    private Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player == null) return;

        if (!isAttacking)
        {
            StartCoroutine(PerformAttack());
        }
    }

    private IEnumerator PerformAttack()
    {
        isAttacking = true;
        int attackChoice = Random.Range(0, 100);

        switch (bossType)
        {
            case BossType.TheAberration:
                if (attackChoice < 50) TentacleSmash();
                else MindScream();
                break;

            case BossType.TheLurker:
                if (attackChoice < 50) ShadowStep();
                else CorruptingGaze();
                break;

            case BossType.TheFleshMonstrosity:
                if (attackChoice < 50) FleshWhip();
                else SpawnLeeches();
                break;

            case BossType.TheAncientOne:
                if (attackChoice < 50) CosmicBlast();
                else SummonVoidEntities();
                break;
        }

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    private void TentacleSmash()
    {
        Debug.Log("Der Boss schlägt mit riesigen Tentakeln zu!");
        animator.SetTrigger("TentacleSmash");
    }

    private void MindScream()
    {
        Debug.Log("Der Boss schreit und verursacht Wahnsinnsschaden!");
        animator.SetTrigger("MindScream");
    }

    private void ShadowStep()
    {
        Debug.Log("Der Boss teleportiert sich und erscheint woanders!");
        animator.SetTrigger("ShadowStep");
    }

    private void CorruptingGaze()
    {
        Debug.Log("Der Boss starrt den Spieler an und schwächt ihn!");
        animator.SetTrigger("CorruptingGaze");
    }

    private void FleshWhip()
    {
        Debug.Log("Der Boss schlägt mit seiner Fleischpeitsche!");
        animator.SetTrigger("FleshWhip");
    }

    private void SpawnLeeches()
    {
        Debug.Log("Der Boss spawnt kleine Blutsauger!");
        animator.SetTrigger("SpawnLeeches");
    }

    private void CosmicBlast()
    {
        Debug.Log("Der Boss entfesselt eine kosmische Explosion!");
        animator.SetTrigger("CosmicBlast");
    }

    private void SummonVoidEntities()
    {
        Debug.Log("Der Boss beschwört Wesen aus dem Nichts!");
        animator.SetTrigger("SummonVoidEntities");
    }

    public void ActivateSecondPhase()
    {
        isSecondPhase = true;
        attackCooldown /= 2;
        Debug.Log("Der Boss wird aggressiver und seine Angriffe ändern sich!");
    }
}
