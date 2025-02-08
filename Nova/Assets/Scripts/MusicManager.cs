using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip[] backgroundTracks;

    void Start()
    {
        PlayRandomTrack();
    }

    void PlayRandomTrack()
    {
        if (backgroundTracks.Length > 0)
        {
            int randomIndex = Random.Range(0, backgroundTracks.Length);
            musicSource.clip = backgroundTracks[randomIndex];
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
    }
}
