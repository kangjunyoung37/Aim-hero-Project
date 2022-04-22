using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandGun : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip audioTakeOutWeapon;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); 

    }
    private void OnEnable()
    {
        PlaySound(audioTakeOutWeapon);
    }
    private void PlaySound(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = audioTakeOutWeapon;
        audioSource.Play();
    }

}
