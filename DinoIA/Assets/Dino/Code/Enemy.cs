using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float mass = 1;
    
    public bool isSeek;
    public bool isFlee;

    void Update()
    {
        if (isFlee && !isSeek)
        {
            SteerinngBehaviors.Instance.CalculateFlee(gameObject , player, mass);
        }

        if (isSeek && !isFlee)
        {
            SteerinngBehaviors.Instance.CalculateSeekBH(gameObject , player, mass);
        }
    }
}
