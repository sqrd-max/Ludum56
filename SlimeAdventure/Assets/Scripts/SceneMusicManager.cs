using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMusicManager : MonoBehaviour
{
    public AudioClip scene1Music; // Музыка для первой сцены
    public AudioClip scene2Music; // Музыка для второй сцены

    private AudioSource audioSource;

    void Start()
    {
        // Создаём или получаем компонент AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true; // Зациклить музыку
        PlaySceneMusic();
    }

    // Воспроизводит музыку в зависимости от текущей сцены
    void PlaySceneMusic()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case "SlimeScene": // Имя первой сцены
                audioSource.clip = scene1Music;
                break;

            case "InBattleScene": // Имя второй сцены
                audioSource.clip = scene2Music;
                break;

            default:
                return; // Если сцена не указана, музыка не проигрывается
        }

        audioSource.Play();
    }
}
