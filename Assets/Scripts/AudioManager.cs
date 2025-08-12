using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource BackgroundAudioSource;
    [SerializeField] private AudioSource EfectAudioSource;

    [SerializeField] private AudioClip BackgoundClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip coinClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayBackGroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBackGroundMusic()
    {
        BackgroundAudioSource.clip = BackgoundClip;
        BackgroundAudioSource.Play();
    }

    public void PlayCoinSound()
    {
        EfectAudioSource.PlayOneShot(coinClip);
    }
    public void PlayJumpSound()
    {
        EfectAudioSource.PlayOneShot(jumpClip);
    }

}
