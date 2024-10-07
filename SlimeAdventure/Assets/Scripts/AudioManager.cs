using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton, чтобы другие скрипты могли легко получить доступ

    public AudioClip buttonClickSound; // «вук нажати€ кнопки
    private AudioSource audioSource;

    private void Awake()
    {
        // –еализаци€ Singleton, чтобы существовал только один экземпл€р AudioManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // —охран€ть этот объект при смене сцены
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
        else
        {
            Destroy(gameObject); // ”далить дубликат, если экземпл€р уже существует
        }
    }

    // ћетод дл€ воспроизведени€ звука нажати€ кнопки
    public void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}
