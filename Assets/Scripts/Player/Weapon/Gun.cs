using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void Shoot(GameObject prefab, AudioClip audio)
    {
        Instantiate(prefab, transform.position, transform.rotation);
        PlaySound(audio);
    }

    private void PlaySound(AudioClip audio)
    {
        _audioSource.clip = audio;
        _audioSource.Play();
    }
}