using UnityEngine;

public class PlaySoundOnSceneStart : MonoBehaviour
{
    public AudioClip sceneStartSound; // ����, ������� ����� ������������� ��� ������ �����
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // �� ����������� ���� ��� �������� AudioSource
        audioSource.clip = sceneStartSound;

        PlaySceneStartSound();
    }

    // ����� ��� ��������������� ����� ��� ������� �����
    private void PlaySceneStartSound()
    {
        if (sceneStartSound != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("���� �� �������� � ����������.");
        }
    }
}
