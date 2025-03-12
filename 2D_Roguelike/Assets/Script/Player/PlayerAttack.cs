using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform attackPoint;
    public float projectileSpeed = 10f;

    private Vector2 attackDirection = Vector2.right; // Standard: Nach rechts

    private void Update()
    {
        SetAttackDirection();

        if (Input.GetMouseButtonDown(0)) // Linksklick
        {
            Attack();
        }
    }

    private void SetAttackDirection()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            attackDirection = new Vector2(1, 1).normalized; // 45� nach rechts oben
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            attackDirection = new Vector2(-1, 1).normalized; // 45� nach links oben
        }
        else if (Input.GetKey(KeyCode.W))
        {
            attackDirection = Vector2.up; // Nach oben
        }
        else if (Input.GetKey(KeyCode.S))
        {
            attackDirection = Vector2.down; // Nach unten
        }
        else
        {
            attackDirection = Vector2.right * (Input.GetKey(KeyCode.A) ? -1 : 1); // Standard nach links oder rechts
        }
    }

    private void Attack()
    {
        GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.linearVelocity = attackDirection * projectileSpeed;
        Destroy(projectile, 2f); // Projektil verschwindet nach 2 Sekunden
    }
}
