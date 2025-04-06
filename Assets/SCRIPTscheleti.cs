using UnityEngine;

public class SCRIPTscheleti : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // SoundHandler
    AudioScriptMiddleAge audioScript;
    private void Awake(){
        audioScript = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioScriptMiddleAge>();
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventoryMiddleAge playerInventoryMiddleAge = other.GetComponent<PlayerInventoryMiddleAge>();

        if (playerInventoryMiddleAge != null)
        {
            audioScript.PlayDeath();
            playerInventoryMiddleAge.EnemiesKilled();
        }
    }
}
