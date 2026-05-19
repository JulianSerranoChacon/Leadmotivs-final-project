using UnityEngine;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
