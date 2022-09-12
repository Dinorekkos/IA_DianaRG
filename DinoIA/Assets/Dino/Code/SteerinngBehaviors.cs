using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerinngBehaviors : MonoBehaviour
{

    public float speed = 7;
    public float mass = 1;
    public float T = 1;
    public void CalculateSeekBH(GameObject target)
    {
        
        Vector3 currentVel = Vector3.zero;
        Vector3 steering;
        Vector3 desiredVelocity;
        
        Vector3 distance = this.transform.position - target.transform.position;
        desiredVelocity = distance.normalized * (speed / mass);
        steering = desiredVelocity - currentVel;
        currentVel += steering * Time.deltaTime;

        this.transform.position -= CalculateArrival(distance, currentVel);
    }

    public void CalculateFlee(GameObject target)
    {
        Vector3 currentVel = Vector3.zero;
        Vector3 steering;
        Vector3 desiredVelocity;
        
        Vector3 distance = target.transform.position - this.transform.position ;
        
        desiredVelocity = distance.normalized  * (speed/mass) ;

        steering = desiredVelocity - currentVel;
        currentVel += steering * Time.deltaTime;


        this.transform.position -= CalculateFarAway(distance, currentVel);
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
    
    public Vector3 Seek_WITHOUTARRIVAL(GameObject target)
    {
        
        Vector3 currentVel = Vector3.zero;
        Vector3 steering;
        Vector3 desiredVelocity;
        
        Vector3 distance = this.transform.position - target.transform.position;
        desiredVelocity = distance.normalized * (speed / mass);
        steering = desiredVelocity - currentVel;
        currentVel += steering * Time.deltaTime;

        this.transform.position -= currentVel;

        return currentVel;
    }

    public void DoPursuit(Vector3 seek, bool dynamic, PlayerMove player)
    {
        
    }
}
