using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMusicManager : MonoBehaviour
{
    public AudioClip scene1Music; // ������ ��� ������ �����
    public AudioClip scene2Music; // ������ ��� ������ �����

    private AudioSource audioSource;

    void Start()
    {
        // ������ ��� �������� ��������� AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true; // ��������� ������
        PlaySceneMusic();
    }

    // ������������� ������ � ����������� �� ������� �����
    void PlaySceneMusic()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case "SlimeScene": // ��� ������ �����
                audioSource.clip = scene1Music;
                break;

            case "InBattleScene": // ��� ������ �����
                audioSource.clip = scene2Music;
                break;

            default:
                return; // ���� ����� �� �������, ������ �� �������������
        }

        audioSource.Play();
    }
}
