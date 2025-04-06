using UnityEngine;

public class AudioMiddleAge : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource portalSource;
    [SerializeField] AudioSource deathSource;
    public AudioClip background;
    public AudioClip portal;
    public AudioClip death;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
