using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad = 5;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            SceneManager.LoadScene(sceneIndexToLoad);
        }
    }
}
