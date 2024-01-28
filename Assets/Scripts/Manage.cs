using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Status = Player.PlayerStatus;

public class Manage : MonoBehaviour
{
    public float left_Time = 100f;
    public float TimeThread = 1f;
    private float time = 1f;
    public AudioSource PlayerAudioSource;

    #region Slary_Energy_Change

    [Header("各个状态对应属性")] public int Come_Idle_Slary;
    public int Come_Work_Slary;
    public int Come_WorkAdd_Slary;
    public int Come_WorkLess_Slary;
    public int Come_Recharge_Slary;
    public int Come_Idle_Energy;
    public int Come_Work_Energy;
    public int Come_WorkAdd_Energy;
    public int Come_WorkLess_Energy;
    public int Come_Recharge_Energy;
    public int Come_WordAdd_Award;

    public int NoCome_Idle_Slary;
    public int NoCome_Work_Slary;
    public int NoCome_WorkAdd_Slary;
    public int NoCome_WorkLess_Slary;
    public int NoCome_Recharge_Slary;
    public int NoCome_Idle_Energy;
    public int NoCome_Work_Energy;
    public int NoCome_WorkAdd_Energy;
    public int NoCome_WorkLess_Energy;
    public int NoCome_Recharge_Energy;
    public int NoCome_Recharhe_Award;

    #endregion

    #region Signle_Instance

    private static Manage _instance;

    public static Manage Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.Find("Manage").GetComponent<Manage>();
            return _instance;
        }
    }

    #endregion

    private void Awake()
    {
        if (Manage.Instance.gameObject != gameObject)
            Destroy(gameObject);
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        Screen.SetResolution(1920, 1080, false);
    }

    private void Update()
    {
        if (Player.Instance.status != Status.PAUSE)
        {
            // Debug.Log("---");
            left_Time -= Time.deltaTime;
            if (left_Time <= 0)
            {
                Player.Instance.status = Player.PlayerStatus.PAUSE;
                End.Instance.LoadEnd(End.EndType.NORMAL);
            }
            else
            {
                if (Input.GetKey(KeyCode.A))
                {
                    Player.Instance.status = Player.PlayerStatus.workLess;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    Player.Instance.status = Player.PlayerStatus.Work;
                }
                else if (Input.GetKey(KeyCode.Q))
                {
                    if (!Boss.Instance.isLooking && Player.Instance.award >= -NoCome_Recharhe_Award)
                    {
                        Player.Instance.status = Player.PlayerStatus.Recharge;
                        // AudioManage.PlayAudio(PlayerAudioSource);
                    }
                    else
                        Player.Instance.status = Player.PlayerStatus.Idle;
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    if (Boss.Instance.isLooking)
                        Player.Instance.status = Player.PlayerStatus.workMore;
                    else
                        Player.Instance.status = Player.PlayerStatus.Idle;
                }
                else
                {
                    // PlayerAudioSource.Pause();
                    Player.Instance.status = Player.PlayerStatus.Idle;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            PlayerJudge();
            time = TimeThread;
        }
    }

    void PlayerJudge()
    {
        if (Boss.Instance.isLooking)
        {
            switch (Player.Instance.status)
            {
                case Status.Idle:
                    Player.Instance.Change(Come_Idle_Energy, Come_Idle_Slary);
                    break;
                case Status.Work:
                    Player.Instance.Change(Come_Work_Energy, Come_Work_Slary);
                    break;
                case Status.workMore:
                    Player.Instance.Change(Come_WorkAdd_Energy, Come_WorkAdd_Slary, Come_WordAdd_Award);
                    break;
                case Status.workLess:
                    Player.Instance.Change(Come_WorkLess_Energy, Come_WorkLess_Slary);
                    break;
                case Status.Recharge:
                    Player.Instance.Change(Come_Recharge_Energy, Come_Recharge_Slary);
                    break;
                case Status.PAUSE:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        else
        {
            switch (Player.Instance.status)
            {
                case Status.Idle:
                    Player.Instance.Change(NoCome_Idle_Energy, NoCome_Idle_Slary);
                    break;
                case Status.Work:
                    Player.Instance.Change(NoCome_Work_Energy, NoCome_Work_Slary);
                    break;
                case Status.workMore:
                    Player.Instance.Change(NoCome_WorkAdd_Energy, NoCome_WorkAdd_Slary);
                    break;
                case Status.workLess:
                    Player.Instance.Change(NoCome_WorkLess_Energy, NoCome_WorkLess_Slary);
                    break;
                case Status.Recharge:
                    Player.Instance.Change(NoCome_Recharge_Energy, NoCome_Recharge_Slary, NoCome_Recharhe_Award);
                    break;
                case Status.PAUSE:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }


    public int Day = 1;
}