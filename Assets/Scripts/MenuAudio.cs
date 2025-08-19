using UnityEngine;

public class MenuAudio : MonoBehaviour
{
   [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource menuSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip --------")]
    public AudioClip background;

    private void Start()
    {
        menuSource.clip = background;
        menuSource.Play();
    }
}
