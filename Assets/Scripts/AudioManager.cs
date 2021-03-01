using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] MusicList;

    private AudioSource m_AudioSource;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!m_AudioSource.isPlaying)
        {
            m_AudioSource.clip = MusicList[Random.Range(0, MusicList.Length)];
            m_AudioSource.Play();
        }
    }
}