using UnityEngine;
using UnityEngine.SceneManagement; // Pentru schimbare scenă

public class BedCutscene : MonoBehaviour
{
    private bool isNearBed = false;

    public Animator animator; // Pune aici Animatorul personajului tău

    void Update()
    {
        if (isNearBed && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Dormim...");
            animator.SetTrigger("GoToSleep");

            // Așteptăm 2 secunde și apoi mergem la scenă nouă (visul)
            // Invoke("GoToDreamScene", 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bed"))
        {
            isNearBed = true;
            Debug.Log("Ești lângă pat. Apasă E ca să dormi.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bed"))
        {
            isNearBed = false;
        }
    }

    // private void GoToDreamScene()
    // {
    //     SceneManager.LoadScene("DreamScene"); // Asigură-te că scena există în Build Settings
    // }
}
