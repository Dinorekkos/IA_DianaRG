using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SteerinngBehaviors.Instance.CalculateSeekBH(gameObject , player);
        // SteerinngBehaviors.Instance.CalculateFlee(gameObject , player);
    }
}
