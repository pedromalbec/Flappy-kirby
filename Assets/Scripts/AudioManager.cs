using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource entranceSource;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip --------")]
    public AudioClip entrance;
    public AudioClip background;
    public AudioClip fly;

    [Header("-------- Entrance Duration --------")]
    public float entranceDuration;

    private void Start()
    {
        entranceSource.clip = entrance;
        entranceSource.Play();

        Invoke("Bg", entranceDuration);
    }

    private void Bg()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
