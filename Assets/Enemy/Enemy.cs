using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float attackCooldown = 2.0f;  // Timpul de cooldown dintre atacuri
    public int maxHealth = 100;          // Viața maximă a inamicului
    public int currentHealth;            // Viața curentă
    public int damage = 10;              // Cât de mult damage face inamicul
    private float lastAttackTime = 0f;   // Timpul la care a fost ultimul atac
    private Animator animator;            // Referința la Animator-ul inamicului

    void Start()
    {
        currentHealth = maxHealth;  // Setați viața curentă la maxim
        animator = GetComponent<Animator>();  // Asigură-te că referința la animator este setată
    }

    void Update()
    {
        // Dacă inamicul este pe cooldown, nu poate ataca
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            // Căutăm jucătorul (presupunem că are tag-ul "Player")
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                // Calculăm distanța față de jucător
                float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

                // Dacă jucătorul este destul de aproape pentru a ataca
                if (distanceToPlayer <= 2f)  // Raza de atac
                {
                    // Execută atacul
                    AttackPlayer(player);
                }
                else
                {
                    // Mergi spre jucător
                    MoveTowardsPlayer(player);
                }
            }
        }
    }

    void AttackPlayer(GameObject player)
    {
        // Dacă nu este deja pe cooldown, atacă
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            animator.SetTrigger("Hit");  // Activează animația de atac
            lastAttackTime = Time.time;  // Resetăm timpul pentru cooldown

            // Aplica damage pe jucător
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);  // Aplica damage
            }
        }
    }

    void MoveTowardsPlayer(GameObject player)
    {
        // Mișcă inamicul spre jucător
        transform.LookAt(player.transform);  // Se rotește spre jucător
        transform.Translate(Vector3.forward * Time.deltaTime * 2);  // Mișcare spre jucător

        // Dacă inamicul se mișcă, declanșează animația de mers
        animator.SetBool("isWalking", true);
    }

    public void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;  // Scade viața inamicului
        animator.SetBool("isBeingHit", true);  // Declanșează animația de "BeingHit"

        if (currentHealth <= 0)
        {
            Die();  // Dacă moare, începe animația de moarte
        }
    }

    void Die()
    {
        animator.SetTrigger("die");  // Declanșează animația de moarte
        Destroy(gameObject, 2f);  // Distruge inamicul după 2 secunde (pentru a permite animația să se joace)
    }

    void OnTriggerEnter(Collider other)
    {
        // Dacă inamicul intră în contact cu jucătorul, îl atacă
        if (other.CompareTag("Player"))
        {
            TakeDamage(20);  // Jucătorul dă damage inamicii (poți să ajustezi valoarea)
        }
    }
}
