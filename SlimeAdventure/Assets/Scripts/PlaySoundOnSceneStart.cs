using UnityEngine;

public class PlaySoundOnSceneStart : MonoBehaviour
{
    public AudioClip sceneStartSound; // Звук, который будет проигрываться при старте сцены
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // Не проигрывать звук при создании AudioSource
        audioSource.clip = sceneStartSound;

        PlaySceneStartSound();
    }

    // Метод для воспроизведения звука при запуске сцены
    private void PlaySceneStartSound()
    {
        if (sceneStartSound != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Звук не назначен в инспекторе.");
        }
    }
}
