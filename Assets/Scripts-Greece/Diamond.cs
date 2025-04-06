using UnityEngine;

public class Diamond : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    AudioGrecia audioGrecia;
    private void Awake()
    {
        audioGrecia = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioGrecia>();
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            audioGrecia.PlayCollect(audioGrecia.collectingSound);
            playerInventory.DiamondCollected();
            gameObject.SetActive(false);
        }
    }
}
