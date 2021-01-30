using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof (AudioSource))]
public class AudioController : Singleton<AudioController> {
    public AudioClip SFXGood;
    public AudioClip SFXWrong;
    public AudioClip IngameMusic;
    public AudioClip MenuMusic;
    public AudioSource source;

    public AudioClip SFXVoor;
    public AudioClip SFXMidden;
    public AudioClip SFXAchter;
    public AudioClip SFXAlles;

    private GameController _gameController;
    public GameObject AudioButton;

	public float masterVolume;
	public float voiceVolume;

    void Start() {
        _gameController = GameController.Instance;
    }

	public void OnVolumeChange(){
		source.volume = masterVolume;
	}

    #region background_music
    public void ChangeBackgroundMusic(AudioClip targetMusic) {
        targetAudio = targetMusic;
        StartCoroutine("ChangeBackgroundMusicRoutine");
    }

    private AudioClip targetAudio;
    private IEnumerator ChangeBackgroundMusicRoutine() {
        yield return StartCoroutine("AudioFadeOut");
        source.clip = targetAudio;
        source.Play();
        yield return StartCoroutine("AudioFadeIn");
    }

    private IEnumerator AudioFadeOut() {
        while (source.volume > 0.1f) {
            source.volume -= 0.01f;
            yield return new WaitForEndOfFrame();
        }

    }

    private IEnumerator AudioFadeIn() {
        while (source.volume < 0.5f) {
            source.volume += 0.01f;
            yield return new WaitForEndOfFrame();
        }

    }
    #endregion


    public void PlaySound(AudioClip targetClip) {
        AudioSource.PlayClipAtPoint(targetClip,transform.position);

    }

    public void PlaySound(AudioClip targetClip,float volume) {
        AudioSource.PlayClipAtPoint(targetClip,transform.position,volume);

    }


    public void TurnBackgroundMusic(bool targetSwitch) {
        if(targetSwitch == false) {
            source.Play();
        }else {
            source.Stop();
        }
    }
    public void CreateAudioButton() {
        AudioButton.SetActive(true);
    }

    public void DestroyAudioButton() {
        AudioButton.SetActive(false);
    }


    
}
