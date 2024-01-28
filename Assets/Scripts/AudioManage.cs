using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManage : MonoBehaviour
{
    public AudioSource audioSource;
    //public AudioSource playerAudio;
    //public Player player;
    public AudioClip WorkTired, WorkKeyB, workMore, workLess, Recharge;

    #region Signle_Instance

    private static AudioManage _instance;

    public static AudioManage Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.Find("Manage").GetComponent<AudioManage>();
            return _instance;
        }
    }

    #endregion
    public AudioSource BackAudioSource;
    
    private void Update()
    {
        PlayerAudio();

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            if (Player.Instance.status == Player.PlayerStatus.Work)
            {
                Player.Instance.gameObject.GetComponent<AudioSource>().Play();
            }
            else
            {
                Player.Instance.gameObject.GetComponent<AudioSource>().Pause();
            }
        }
    }

    public static void PlayAudio(AudioSource audioSource)
    {
        audioSource.Play();
    }

    public static IEnumerator PlayAudio(AudioSource audioSource, AudioClip audioClip ,float time)
    {
        yield return time;
        audioSource.PlayOneShot(audioClip);
    }

    public void PlayerAudio()
    {
        if (Player.Instance.status == Player.PlayerStatus.workLess)
        {
            audioSource.clip = workLess;
        }
        else if (Player.Instance.status == Player.PlayerStatus.Work)
        {
            audioSource.clip = WorkTired;

        }
        else if (Player.Instance.status == Player.PlayerStatus.Recharge)
        {
            audioSource.clip = Recharge;
        }
        else if (Player.Instance.status == Player.PlayerStatus.workMore)
        {
            audioSource.clip = workMore;
        }
        else if (Player.Instance.status == Player.PlayerStatus.Idle)
        {
            audioSource.Stop();
        }
        else if (Player.Instance.status == Player.PlayerStatus.PAUSE)
        {
            audioSource.Stop();
        }
    }
}
