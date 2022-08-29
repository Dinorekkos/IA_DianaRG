using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerinngBehaviors : MonoBehaviour
{
    public static SteerinngBehaviors Instance;
    public float speed = 5;
 
    void Start()
    {
        Instance = this;
    }

  
    void Update()
    {

    }

    public void CalculateSeekBH(GameObject enemy, GameObject target)
    {
        
        Vector3 currentVel = Vector3.zero;
        Vector3 steering;
        Vector3 desiredVelocity;
        
        Vector3 distance = enemy.transform.position - target.transform.position;
        
        desiredVelocity = distance.normalized * (speed);
        steering = desiredVelocity - currentVel;
        currentVel += steering * Time.deltaTime;

       
        
        enemy.transform.position -=  CalculateArrival(distance, currentVel);;
    }

    public void CalculateFlee(GameObject enemy, GameObject target)
    {
        Vector3 currentVel = Vector3.zero;
        Vector3 steering;
        Vector3 desiredVelocity;
        
        Vector3 distance = target.transform.position - enemy.transform.position ;
        
        desiredVelocity = distance.normalized  * speed ;

        steering = desiredVelocity - currentVel;
        currentVel += steering * Time.deltaTime;

        // CalculateArrival(distance, currentVel);

        enemy.transform.position -= currentVel;
    }

    public Vector3 CalculateArrival(Vector3 distance, Vector3 currenVel)
    {
        Vector3 arrival = Vector3.zero;
        float magnitude = distance.magnitude;
        float radius = 3f;

        if (magnitude < radius)
        {
            arrival = currenVel * 0.5f;
        }

        return arrival;
    }
}
