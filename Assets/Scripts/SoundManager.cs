using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class SoundManager : Singleton<SoundManager>
    {
        public AudioSource effectsSource;
        public AudioSource musicSource;

        public void PlayEffect(AudioData audioData)
        {
            effectsSource.pitch = audioData.pitch;
            effectsSource.PlayOneShot(audioData.clip, audioData.volume);
        }
        public void PlayMusic(AudioData audioData)
        {
            musicSource.clip = audioData.clip;
            musicSource.volume = audioData.volume;
            musicSource.pitch = audioData.pitch;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
}