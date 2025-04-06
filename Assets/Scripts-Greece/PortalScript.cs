using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PortalScript : MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad = 3;

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered) return;

        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            isTriggered = true;
            StartCoroutine(LoadSceneAfterDelay());
        }
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(2f); // Așteaptă 2 secunde
        SceneManager.LoadScene(3);
    }
}
