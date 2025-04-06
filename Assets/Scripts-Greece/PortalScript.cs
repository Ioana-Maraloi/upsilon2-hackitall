using UnityEngine;

public class PortalScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject secretPanel; public int NumberOfDiamonds { get; private set; }

    private void OniggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            secretPanel.SetActive(true);
        }
    }
}
