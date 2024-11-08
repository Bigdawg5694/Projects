using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool initalized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// gets if audio manager is initialized or not
    /// </summary>
    public static bool Initalized
    {
        get { return initalized; }
    }

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        initalized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.ButtonSound,
        Resources.Load<AudioClip>("button"));
        audioClips.Add(AudioClipName.BallSpawnSound,
            Resources.Load<AudioClip>("ballSpawn"));
        audioClips.Add(AudioClipName.BallHitSound,
            Resources.Load<AudioClip>("ballHit"));
        audioClips.Add(AudioClipName.BallLostSound,
            Resources.Load<AudioClip>("ballLost"));
        audioClips.Add(AudioClipName.GameLostSound,
            Resources.Load<AudioClip>("gameOver"));
        audioClips.Add(AudioClipName.SpeedupSound,
            Resources.Load<AudioClip>("speedup"));
        audioClips.Add(AudioClipName.FreezerSound,
            Resources.Load<AudioClip>("freeze"));
        audioClips.Add(AudioClipName.FreezerDeactivateSound,
            Resources.Load<AudioClip>("freezeDeactivate"));
        audioClips.Add(AudioClipName.SpeedupDeactivateSound,
            Resources.Load<AudioClip>("speedupDeactivate"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
