using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] scream_Clip;
    [SerializeField]
    private AudioClip[]  die_Clip;

    [SerializeField]
    private AudioClip[] attack_Clips;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play_ScreamSound()
    {
        audioSource.clip = scream_Clip[Random.Range(0, scream_Clip.Length)];
        audioSource.Play();
    }

    public void Play_AttackSound()
    {
        audioSource.clip = attack_Clips[Random.Range(0, attack_Clips.Length)];
        audioSource.Play();
    }

    public void Play_DeadSound()
    {
        audioSource.clip = die_Clip[Random.Range(0, die_Clip.Length)];
        audioSource.Play();
    }

}
