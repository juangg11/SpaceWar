using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource sfxSource;
    public AudioClip disparo;
    public AudioClip explosion;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySound(string soundName)
    {
        switch (soundName)
        {
            case "jump":
                sfxSource.PlayOneShot(disparo);
                break;
            case "explosion":
                sfxSource.PlayOneShot(explosion);
                break;
        }
    }
}
