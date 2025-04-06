using UnityEngine;

public class PickupSword : MonoBehaviour
{
    [Header("Referințe")]
    public Transform playerHand;          // Transform-ul mâinii jucătorului
    public GameObject swordInHand;        // Sabia care apare în mână
    public Animator playerAnimator;       // Animator-ul jucătorului

    [Header("Setări")]
    public string pickupTriggerName = "PickupSword";  // Trigger-ul din Animator

    private bool pickedUp = false;

    private void OnTriggerEnter(Collider other)
    {
        // Verificăm dacă intră jucătorul și nu s-a făcut pickup deja
        if (!pickedUp && other.CompareTag("Player"))
        {
            pickedUp = true;

            // 🔹 Activăm trigger-ul pentru animația de pickup
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger(pickupTriggerName);
            }

            // 🔹 Pornim coroutine ca să "echipăm" sabia după ce se termină animația
            StartCoroutine(EquipSwordAfterPickup());
        }
    }

    private System.Collections.IEnumerator EquipSwordAfterPickup()
    {
        // Așteaptă puțin cât durează animația de pickup (ajustează timpul dacă e nevoie)
        yield return new WaitForSeconds(1.2f);

        // 🔹 Dezactivează sabia de pe jos (sabia actuală)
        gameObject.SetActive(false);

        // 🔹 Activează sabia din mână
        if (swordInHand != null)
        {
            swordInHand.SetActive(true);
            swordInHand.transform.SetParent(playerHand);
            swordInHand.transform.localPosition = Vector3.zero;
            swordInHand.transform.localRotation = Quaternion.identity;
        }
    }
}
