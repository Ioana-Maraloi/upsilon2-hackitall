using UnityEngine;
using TMPro;

public class ClockManager : MonoBehaviour
{
    public TextMeshProUGUI clockText; // Referință la TextMeshPro UI
    public float timeScale = 1.0f;    // Viteza normală a ceasului
    private float currentTime = 0f;    // Timpul curent în secunde

    void Update()
    {
        // Actualizează timpul
        currentTime += Time.deltaTime * timeScale;

        // Formatare HH:MM:SS
        int hours = (int)(currentTime / 3600) % 24;
        int minutes = (int)(currentTime / 60) % 60;
        int seconds = (int)currentTime % 60;

        // Afișează timpul
        clockText.text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }

    // Funcție pentru a accelera ceasul
    public void AccelerateClock(float accelerationFactor)
    {
        timeScale *= accelerationFactor; // Ex: 2.0f pentru dublarea vitezei
    }
}