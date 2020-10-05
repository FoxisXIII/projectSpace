using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ? 2017 TheFlyingKeyboard 
// theflyingkeyboard.net
public class MorseCodeTranslator : MonoBehaviour
{
    [SerializeField] private float dotTime;
    [SerializeField] private GameObject objectToUse;
    [SerializeField] private AudioClip dotAudio;
    [SerializeField] private AudioClip hyphenAudio;

    [TextAreaAttribute(4, 15)] [SerializeField]
    private string textToShow;

    private float _dashTime;

    private char[] letters =
    {
        ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
        'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'
    };

    private string[] morseLetters =
    {
        "    ", "._", "_...", "_._.", "_..", ".", ".._.", "__.", "....", "..", ".___", "_._",
        "._..", "__", "_.", "___", ".__.", "__._", "._.", "...", "_", ".._", "..._", ".__",
        "_.._", "_.__", "__..", ".____", "..___", "...__", "...._", ".....", "_....",
        "__...", "___..", "____.", "_____"
    };

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(Flash(objectToUse, textToShow, dotTime));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        objectToUse.SetActive(false);
    }

    private IEnumerator Flash(GameObject objectToFlash, string textToConvert, float timeOfDot)
    {
        string textInMorse = "";
        ConvertTextToMorseCode(textToConvert, out textInMorse);
        for (int i = 0; i < textInMorse.Length; i++)
        {
            if (textInMorse[i] == ' ')
            {
                objectToFlash.SetActive(false);
                yield return 0;
                yield return new WaitForSeconds(timeOfDot);
            }
            else if (textInMorse[i] == '.')
            {
                objectToFlash.SetActive(true);
                ChangeAudio(dotAudio);
                yield return 0;
                yield return new WaitForSeconds(dotAudio.length + timeOfDot);
            }
            else if (textInMorse[i] == '_')
            {
                objectToFlash.SetActive(true);
                ChangeAudio(hyphenAudio);
                yield return 0;
                yield return new WaitForSeconds(hyphenAudio.length + timeOfDot);
            }

            objectToFlash.SetActive(false);
            yield return 0;
            yield return new WaitForSeconds(timeOfDot);

            if (i == textInMorse.Length - 1)
            {
                i = 0;
            }
        }
    }

    private void ChangeAudio(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }

    private void ConvertTextToMorseCode(string textToConvert, out string convertedText)
    {
        convertedText = "";
        textToConvert = textToConvert.ToLower();
        for (int i = 0; i < textToConvert.Length; i++)
        {
            for (short j = 0; j < 37; j++)
            {
                if (textToConvert[i] == letters[j])
                {
                    convertedText += morseLetters[j];
                    convertedText += " ";
                    break;
                }
            }
        }
    }
}