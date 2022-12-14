using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AlienImmigration;
using UnityEngine.Rendering;

namespace AlienImmigration.Audio
{

    public class AudioManager : MonoBehaviour
    {
        #region Fields

        [SerializeField] private AudioSource menuMusic;
        [SerializeField] private AudioSource boothMusic;
        [SerializeField] private AudioSource clickSounds;
        [SerializeField, Range(0, 1)] private float musicVolume;

        #endregion

        #region Public Functions

        public void PlaySFX(AudioClip audioSound)
        {
            if (!clickSounds.isPlaying)
            {
                clickSounds.clip = audioSound;
                clickSounds.Play();
            }
        }

        #endregion

        #region IEnumerators

        private IEnumerator FadeInMusic(AudioSource audioSource)
        {
            while (audioSource.volume < musicVolume)
            {
                yield return new WaitForSeconds(0.05f);
                audioSource.volume += 0.02f;
            }
        }

        private IEnumerator FadeOutMusic(AudioSource audioSource)
        {
            while (audioSource.volume > 0)
            {
                yield return new WaitForSeconds(0.05f);
                audioSource.volume -= 0.02f;
            }
        }

        public IEnumerator PlayMenuMusic()
        {
            if (boothMusic.isPlaying)
            {
                yield return StartCoroutine(FadeOutMusic(boothMusic));
                boothMusic.Stop();
            }

            if (!menuMusic.isPlaying)
            {
                menuMusic.volume = 0;
                menuMusic.Play();

                StartCoroutine(FadeInMusic(menuMusic));
            }
        }

        public IEnumerator PlayBoothMusic()
        {
            if (menuMusic.isPlaying)
            {
                yield return StartCoroutine(FadeOutMusic(menuMusic));
                menuMusic.Stop();
            }

            if (!boothMusic.isPlaying)
            {
                boothMusic.volume = 0;
                boothMusic.Play();

                StartCoroutine(FadeInMusic(boothMusic));
            }
        }

        #endregion

        #region Private Functions


        #endregion

    }
}
