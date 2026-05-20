using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    private AudioSource audioSrc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSrc=GetComponent<AudioSource>();
        audioSrc.clip = clip;
        audioSrc.Play();
        transform.parent.GetComponent<Move>().RegisterMP(this);
    }

    public bool getIsplaying()
    {
        return audioSrc.isPlaying;
    }
}
