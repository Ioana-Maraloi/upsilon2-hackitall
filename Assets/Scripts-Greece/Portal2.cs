using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad = 5;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }
}
