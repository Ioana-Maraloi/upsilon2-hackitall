using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PortalScript : MonoBehaviour
{
    // [SerializeField] private GameObject secretPanel;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            // secretPanel.SetActive(true);
            StartCoroutine(ChangeSceneAfterDelay(2f)); // așteaptă 2 secunde
        }
    }

    IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(2);
    }
}
