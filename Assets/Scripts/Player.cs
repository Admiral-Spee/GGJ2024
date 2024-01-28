using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Player_Property

    [Header("玩家属性")]
    public int energy;
    public int award;
    public int salary;

    public int initialEnergyMax;
    public int initialSalaryMax;

    public int energyMax;
    public int energyMin;
    public int salaryMax;
    public int salaryMin;

    public int salaryUp;
    public int energyUp;

    #endregion

    

    #region Signle_Instance

    private static Player _instance;

    public static Player Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.Find("Player").GetComponent<Player>();
            return _instance;
        }
    }

    #endregion

    public enum PlayerStatus
    {
        Idle,
        Work,
        workMore,
        workLess,
        Recharge,
        PAUSE
    }

    public PlayerStatus status;
    // public Manage manager;
    // public End end;
    public UIManage UI;
    // private void Start()
    // {
    //     manager=Manage.Instance;
    //     end=End.Instance;
    //     UI=UIManage.Instance;
    // }
    public void Change(int energyChange, int salaryChange, int awardChange = 0)
    {
        UI.ChangeSalaryShow(salary, salaryChange);
        energy += energyChange;
        salary += salaryChange;
        award += awardChange;
    }


    // Update is called once per frame
    void Update()
    {
        if (status != PlayerStatus.PAUSE)
        {
            if (energy >= energyMax)
            {
                End.Instance.LoadEnd(End.EndType.WORKLESS); 
                salaryMax = initialSalaryMax;
                energyMax += energyUp;
                //摸鱼仙人结局，玩家大笑
            }
            else if (energy <= energyMin)
            {
                End.Instance.LoadEnd(End.EndType.DIE);
                //猝死结局
            }
            else if (salary >= salaryMax)
            {
                End.Instance.LoadEnd(End.EndType.INVOLUTION);
                salaryMax += salaryUp;
                energyMax = initialEnergyMax;
                //内卷分子结局，老板大笑
            }
            else if (salary <= salaryMin)
            {
                End.Instance.LoadEnd(End.EndType.DISMISS);
                //被炒结局
            }
        }
        
        
    }

    public void Init()
    {
        status = PlayerStatus.Idle;
        energy = energyMax / 2;
        salary = initialSalaryMax / 3;
        award = 0;
    }
}