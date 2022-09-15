using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerinngBehaviors : MonoBehaviour
{
    [Header("Steering Behaviors")] 
    
    public Transform Target;
    public float speed = 7;
    public float mass = 1;
    public float T = 1;
    public Vector3 velocity;


    [Header("Wander")] 
    public bool showVectors;
    
    
    Vector3 desiredVelocity;
    
    

    // public void CalculateFlee(GameObject target)
    // {
        // Vector3 currentVel = Vector3.zero;
        // Vector3 steering;
        // Vector3 desiredVelocity;
        
        // Vector3 distance = target.transform.position - this.transform.position ;
        
        // desiredVelocity = distance.normalized  * (speed/mass) ;

        // steering = desiredVelocity - currentVel;
        // currentVel += steering * Time.deltaTime;


        // this.transform.position -= CalculateFarAway(distance, currentVel);
    // }

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
    
    public Vector3 CalculateSeek(Vector3 target)
    {
        Vector3 distance =  target - transform.position ;
        desiredVelocity = distance.normalized * speed ;
        Vector3 steering = desiredVelocity - velocity;
        Vector3 seek = steering;
        return seek;
    }

    public void CalculatePursuit(Vector3 seek, bool dynamic, PlayerMove player)
    {
        
    }

    public Vector3 CalculateWander(float distanceC, float angle)
    { 
        Vector3 wander = Vector3.zero;
        Vector3 distanceCircle = velocity.normalized * distanceC;
        // Vector3 rotationObject = 
        // Vector3 target = distanceC + 

        
        return wander;
    }
    
    
    
    public Vector3 CalculateWander(float angle, float distanceC, float radius)
    {
        Vector3 distanceCircle = transform.position + (velocity.normalized * distanceC);
        Vector3 rotated = Quaternion.AngleAxis(angle, Vector3.right) * velocity.normalized;
        Vector3 wanderTragetDir = distanceCircle + (rotated * radius);

        if(showVectors)
        {
            Debug.DrawRay(transform.position, distanceCircle - transform.position, Color.blue);
            Debug.DrawRay(distanceCircle, wanderTragetDir - distanceCircle, Color.red);
        }

        return CalculateSeek(wanderTragetDir);
    }


    public void Move(Vector3 steering)
    {
        velocity = Vector3.ClampMagnitude(velocity + steering * Time.deltaTime, speed);
        transform.position += velocity * Time.deltaTime;

        float rotation = Vector3.SignedAngle(Vector3.forward, desiredVelocity,transform.eulerAngles);
        transform.eulerAngles = new Vector3(0, rotation, 0);
    }
}
