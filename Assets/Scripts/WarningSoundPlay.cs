using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WarningSoundPlay : MonoBehaviour
{
    private AudioSource _audioSource;

    private Coroutine _coroutine;
    private bool _IsInside = false;
    private float _maxVolume = 1.0f;
    private float _minVolume = 0f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _IsInside = true;
        _audioSource.Play();
        ChangeMusic();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _IsInside = false;
        ChangeMusic();
    }

    public void ChangeMusic()
    {
        bool isIncrement = true;

        if (_IsInside)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(ChangeMusicCoroutine(isIncrement));
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            isIncrement = false;
            _coroutine = StartCoroutine(ChangeMusicCoroutine(isIncrement));
        }
    }

    public IEnumerator ChangeMusicCoroutine(bool isIncrement)
    {
        float stepVolume = 0.01f;

        for (float i = 0; i < _maxVolume; i += stepVolume)
        {
            if (isIncrement)
            {
                _audioSource.volume += Mathf.MoveTowards(_minVolume, _maxVolume, stepVolume);
                yield return null;
            }
            else
            {

                _audioSource.volume -= Mathf.MoveTowards(_minVolume, 1, stepVolume);
                yield return null;
            }
        }
    }
}
