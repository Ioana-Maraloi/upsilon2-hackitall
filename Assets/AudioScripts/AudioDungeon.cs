using UnityEngine;

public class AudioDungeon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] AudioSource musicSource;
    public AudioClip background;
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        
    }

}
