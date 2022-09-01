using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerinngBehaviors : MonoBehaviour
{
    public static SteerinngBehaviors Instance;
    public float speed = 7;
 
    void Start()
    {
        Instance = this;
    }

    public void CalculateSeekBH(GameObject enemy, GameObject target, float mass)
    {
        
        Vector3 currentVel = Vector3.zero;
        Vector3 steering;
        Vector3 desiredVelocity;
        
        Vector3 distance = enemy.transform.position - target.transform.position;
        desiredVelocity = distance.normalized * (speed / mass);
        steering = desiredVelocity - currentVel;
        currentVel += steering * Time.deltaTime;

        enemy.transform.position -= CalculateArrival(distance, currentVel);
    }

    public void CalculateFlee(GameObject enemy, GameObject target, float mass)
    {
        Vector3 currentVel = Vector3.zero;
        Vector3 steering;
        Vector3 desiredVelocity;
        
        Vector3 distance = target.transform.position - enemy.transform.position ;
        
        desiredVelocity = distance.normalized  * (speed/mass) ;

        steering = desiredVelocity - currentVel;
        currentVel += steering * Time.deltaTime;


        enemy.transform.position -= CalculateFarAway(distance, currentVel);
    }

    public Vector3 CalculateArrival(Vector3 distance, Vector3 currenVel)
    {
        Vector3 arrivalVel = currenVel;
        float magnitude = distance.magnitude;
        float radiusClose = 9f;

        if (magnitude <= radiusClose && magnitude > radiusClose/2)
        {
            arrivalVel = currenVel * 1f;
        }
        else if (magnitude <= radiusClose/2 && magnitude > 1) 
        {
            arrivalVel = currenVel * 0.5f;
        }
        else if (magnitude < 1)
        {
            arrivalVel = currenVel * 0f;
        }
        
        return arrivalVel;
    }


    public Vector3 CalculateFarAway(Vector3 distance, Vector3 currentVel)
    {
        Vector3 lastVel = currentVel;
        float magnitude = distance.magnitude;
        float radiusFarAway = 15f;

        if (magnitude >= radiusFarAway)
        {
            lastVel = Vector3.zero;
        }
        
        return lastVel;
    }
}
