using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton, ����� ������ ������� ����� ����� �������� ������

    public AudioClip buttonClickSound; // ���� ������� ������
    private AudioSource audioSource;

    private void Awake()
    {
        // ���������� Singleton, ����� ����������� ������ ���� ��������� AudioManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ��������� ���� ������ ��� ����� �����
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
        else
        {
            Destroy(gameObject); // ������� ��������, ���� ��������� ��� ����������
        }
    }

    // ����� ��� ��������������� ����� ������� ������
    public void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}
