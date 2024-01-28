using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Animator anim;
    public Player player;

    private int Level;
    public void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        playerAnimations();
    }

    public void playerAnimations()
    {
        anim.SetBool("Work", false);
        anim.SetBool("workMore", false);
        anim.SetBool("workLess", false);
        anim.SetBool("Recharge", false);
        anim.SetBool("Idle", false);
        if(player.status == Player.PlayerStatus.workLess)
        {
            anim.SetBool("workLess",true);
        }
        else if(player.status == Player.PlayerStatus.Work)
        {
            anim.SetBool("Work",true);
        }
        else if(player.status == Player.PlayerStatus.Recharge)
        {
            anim.SetBool("Recharge", true);
        }
        else if(player.status == Player.PlayerStatus.workMore)
        {
            anim.SetBool("workMore", true);
        }
        else if(player.status == Player.PlayerStatus.Idle)
        {
            anim.SetBool("Idle", true);
        }
    }


}
