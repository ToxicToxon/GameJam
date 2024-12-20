using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip jumpscareClip;
    void Start()
    {
        audioPlayer = gameObject.GetComponent<AudioSource>();
    }

    public void jumpscare()
    {
        audioPlayer.loop = false;
        audioPlayer.clip = jumpscareClip;
        audioPlayer.Play();
    }
}
