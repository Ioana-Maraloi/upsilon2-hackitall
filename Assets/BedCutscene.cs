using UnityEngine;
using UnityEngine.SceneManagement; // Pentru schimbare scenă

public class BedCutscene : MonoBehaviour
{
    private bool isNearBed = false;

    public Animator animator; // Animatorul personajului tău
    public Transform bedTransform; // Transformul patului (de plasat în Inspector)
    public float timeAcceleration = 6.0f; // Factorul de accelerație
     public ClockManager clockManager;
    void Update()
    {
        if (isNearBed && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Dormim...");
            animator.SetTrigger("GoToSleep");
            clockManager.AccelerateClock(timeAcceleration);
            // Plasează personajul exact pe pat
            transform.position = bedTransform.position;
            transform.rotation = bedTransform.rotation;

            // Dacă vrei să aștepți câteva secunde înainte de a schimba scena, folosește Invoke
            Invoke("GoToDreamScene", 10f);
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

    private void GoToDreamScene()
    {
        SceneManager.LoadScene(2); // Asigură-te că scena există în Build Settings
    }
}