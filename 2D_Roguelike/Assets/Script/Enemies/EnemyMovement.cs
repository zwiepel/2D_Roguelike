using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float attackRange = 3f;
    public float attackCooldown = 2f;

    public float moveSpeed = 2f;

    private Transform player;
    private bool isAttacking = false;
    private Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            MoveTowardsPlayer();
        }
        else if (!isAttacking)
        {
            StartCoroutine(AttackPlayer());
        }
    }

    private void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        transform.LookAt(player);
    }

    private IEnumerator AttackPlayer()
    {
        isAttacking = true;

        int attackType = Random.Range(0, 100);

        if (attackType < 50)
        {
            PerformAttack("LightAttack");
        }
        else if (attackType < 85)
        {
            PerformAttack("MediumAttack");
        }
        else
        {
            PerformAttack("HeavyAttack");
        }

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    private void PerformAttack(string animationTrigger)
    {
        animator.SetTrigger(animationTrigger);
        Debug.Log($"Gegner führt {animationTrigger} aus!");
        // Hier könnte später eine Spieler-Referenz genutzt werden, um Schaden zuzufügen
    }
}
