using UnityEngine;

public class SwordHit : MonoBehaviour
{
    public Animator playerAnimator;  // Referința la Animator-ul playerului
    public float knockbackForce = 10f;  // Forța cu care va fi aruncat inamicul

    private void OnTriggerEnter(Collider other)
    {
        // Verificăm dacă obiectul care intră în contact are tag-ul "Enemy"
        if (other.CompareTag("Enemy"))
        {
            playerAnimator.SetTrigger("Hit");  // Declanșează animația de hit pe player

            // Căutăm componenta Rigidbody pe inamic
            Rigidbody enemyRigidbody = other.GetComponent<Rigidbody>();
            if (enemyRigidbody != null)
            {
                // Calculăm direcția în care trebuie să aplicăm forța
                Vector3 knockbackDirection = (other.transform.position - transform.position).normalized;

                // Aplicăm forța pentru a-l împinge pe inamic înapoi
                enemyRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
            }

            // Distruge inamicul după un timp
            Destroy(other.gameObject, 2f); // Distruge inamicul după 2 secunde

            // După ce lovim inamicul, jucătorul trebuie să revină la animația de "walking"
            playerAnimator.SetBool("isWalking", true); // Schimbă animația în "walking" (sau orice nume ai folosit pentru "walking")
        }
    }
}
