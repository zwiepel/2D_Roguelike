using UnityEngine;
using System.Collections;

public class PlayerDodge : MonoBehaviour
{
    public float dodgeDistance = 5f; // Wie weit der Dodge geht
    public float dodgeDuration = 0.3f; // Dauer des Dodge
    public float dodgeCooldown = 1f; // Abklingzeit zwischen Dodges

    private CharacterController controller;
    private Animator animator;
    private bool isDodging = false;
    private bool canDodge = true;
    private Vector3 dodgeDirection;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDodge)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            if (horizontalInput > 0) // Vorwärts-Dodge (D)
            {
                dodgeDirection = transform.right;
                StartCoroutine(Dodge("DodgeForward"));
            }
            else if (horizontalInput < 0) // Rückwärts-Dodge (A)
            {
                dodgeDirection = -transform.right;
                StartCoroutine(Dodge("DodgeBackward"));
            }
        }
    }

    private IEnumerator Dodge(string animationTrigger)
    {
        canDodge = false;
        isDodging = true;

        // Dodge-Animation starten
        animator.SetTrigger(animationTrigger);

        float elapsedTime = 0f;

        while (elapsedTime < dodgeDuration)
        {
            controller.Move(dodgeDirection * (dodgeDistance / dodgeDuration) * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isDodging = false;
        yield return new WaitForSeconds(dodgeCooldown);
        canDodge = true;
    }

    public bool IsDodging()
    {
        return isDodging;
    }
}
