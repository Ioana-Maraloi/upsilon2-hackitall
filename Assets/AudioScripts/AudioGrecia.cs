using UnityEngine;

public class AudioGrecia : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created[SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource collectSource;

    public AudioClip background;
    public AudioClip collectingSound;
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlayCollect(AudioClip clip)
    {
        collectSource.PlayOneShot(clip);
        
    }
}
