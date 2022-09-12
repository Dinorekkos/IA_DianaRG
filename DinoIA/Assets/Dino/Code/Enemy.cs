using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : SteerinngBehaviors
{
    public GameObject player;

    private PlayerMove _playerMove;
    public bool pursuitDynamic;
    public bool isSeek;
    public bool isFlee;

    private void Start()
    {
        _playerMove = player.GetComponent<PlayerMove>();
    }

    void Update()
    {
        // if (isFlee && !isSeek)
        // {
        //    CalculateFlee(gameObject , player, mass);
        // }
        //
        // if (isSeek && !isFlee)
        // {
        //   CalculateSeekBH(gameObject , player, mass);
        // }


        DoPursuit(Seek_WITHOUTARRIVAL(player), pursuitDynamic, _playerMove);
    }
}
