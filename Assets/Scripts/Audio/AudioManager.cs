using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private AudioClip[] _musicClips;

    [Range(0f, 1f)] [SerializeField] private float _musicVolume;
    [Range(0f, 1f)] [SerializeField] private float _fxVolume;

    [SerializeField] private bool _musicEnabled;
    [SerializeField] private bool _fxEnabled;

    public static AudioManager instance;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayMusicClip(4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusicClip(int musicClip)
    {
        if (!_musicEnabled || !_audioSource)
        {
            return;
        }

        _audioSource.Stop();
        _audioSource.clip = _musicClips[musicClip];
        _audioSource.volume = _musicVolume;
        _audioSource.loop = true;
        _audioSource.Play();
    }

    public void PlaySoundClip(int soundClip)
    {
        if (_fxEnabled)
        {
            AudioSource.PlayClipAtPoint(_audioClips[soundClip], Camera.main.transform.position, Mathf.Clamp(_fxVolume, 0.05f, 1f));
        }
    }

    public void ToggleFX()
    {
        _fxEnabled = !_fxEnabled;
    }
}
