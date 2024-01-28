using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    public SpriteRenderer SR;
    public Animator anim;
    public AudioSource audioSource;
    public float walkTime;
    public float stopTime;

    [Header("老板属性")]
    public float walkTimeMax;
    public float stopTimeMax;
    public float walkTimeMin = 4.0f;

    public Transform rightPos;
    public Transform leftPos;
    public bool isLooking;
    public bool isFacingRight;
    public int day;

    #region Signle_Instance

    private static Boss _instance;

    public static Boss Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.Find("Boss").GetComponent<Boss>();
            return _instance;
        }
    }

    #endregion

    public void Start()
    {
        GetWalkTime();
        GetStopTime();

        SR = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();

        isFacingRight = true;
        day = Manage.Instance.Day;
    }
    private void Update()
    {
        walkTime -= Time.deltaTime;
        if (walkTime > 0)
        {
            bossWalk();
        }
        else
        {
            bossStop();
        }

    }
    float GetWalkTime()
    {
        walkTimeMin -= day / 3.0f * 1;
        walkTimeMax -= day / 3.0f * 1;
        walkTime = Random.Range(walkTimeMin, walkTimeMax);
        return walkTime;
    }

    float GetStopTime()
    {
        stopTime = GetWalkTime() * 1.5f;
        return stopTime;
    }

    public void bossWalk()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
        anim.SetBool("isLooking", false);
        isLooking = false;

        if (isFacingRight)
        {
            if (Vector2.Distance(transform.position, rightPos.position) < 0.1f)
            {
                SR.flipX = true;
                isFacingRight = false;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, rightPos.position, Time.deltaTime);
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, leftPos.position) < 0.1f)
            {
                SR.flipX = false;
                isFacingRight = true;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, leftPos.position, Time.deltaTime);
            }
        }
    }

    public void bossStop()
    {
        audioSource.Pause();
        stopTime -= Time.deltaTime;
        if (stopTime <= 0)
        {
            GetWalkTime();
            GetStopTime();
        }
        else
        {
            transform.position = transform.position;
            anim.SetBool("isLooking", true);
            isLooking = true;
        }

    }

}