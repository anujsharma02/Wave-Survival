using UnityEngine;
using WaveSurvival.Core;

namespace WaveSurvival.Managers
{
    /*
 * Controls all game audio.
 *
 * Responsibilities:
 * - Plays background music.
 * - Plays sound effects.
 * - Controls music and SFX volume.
 * - Provides global audio access using Singleton.
 */
    public class AudioManager : Singleton<AudioManager>
    {

        [Header("Audio Sources")]
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;

        [Header("Music")]
        [SerializeField] private AudioClip backgroundMusic;

        [Header("Sound Effects")]
        [SerializeField] private AudioClip shootClip;
        [SerializeField] private AudioClip buttonClip;
        [SerializeField] private AudioClip gameOverClip;

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }

        public void PlayShoot()
        {
            sfxSource.PlayOneShot(shootClip);
        }

        public void PlayButton()
        {
            sfxSource.PlayOneShot(buttonClip);
        }

        public void PlayGameOver()
        {
            sfxSource.PlayOneShot(gameOverClip);
        }
    }
}