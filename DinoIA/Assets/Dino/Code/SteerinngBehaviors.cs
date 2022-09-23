using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerinngBehaviors : MonoBehaviour
{
    [Header("Steering Behaviors")] 
    
    public Vector3 _target;
    public float _speed = 7;
    public float _mass = 1;
    public float radiusAway = 10;
    public float radiusArrival= 5;
    public float _T = 1;
    public Vector3 _velocity;
    
    private Vector3 _desiredVelocity;
    
    
    public Vector3 CalculateSeek(Vector3 target, bool hasArrival)
    {
        Vector3 distance =  target - transform.position ;
        _desiredVelocity = distance.normalized * (_speed / _mass);
        Vector3 steering = _desiredVelocity - _velocity;
        Vector3 seek = steering;

        if (hasArrival) seek += CalculateArrival(target);

        return seek;
    }
    public Vector3 CalculateFlee(Vector3 target)
    {
        Vector3 steering = CalculateSeek(target, false);
        steering = -1 * steering;
        
        return steering;
    }

    public Vector3 CalculateArrival(Vector3 distance)
    {
        Vector3 arrivalVel = _velocity;
        float magnitude = distance.magnitude;
        
        if (magnitude <= radiusArrival && magnitude > radiusArrival/2)
        {
            arrivalVel = _velocity * 1f;
        }
        else if (magnitude <= radiusArrival/2 && magnitude > 1) 
        {
            arrivalVel = _velocity * 0.5f;
        }
        else if (magnitude < 1)
        {
            arrivalVel = _velocity * 0f;
        }
        
        print(magnitude);
        return arrivalVel;
    }
    public bool CalculateFarAway(Vector3 distance)
    {
        float magnitude = distance.magnitude;
        if (magnitude >= radiusAway)
        {
            _velocity = Vector3.zero;
            return true;
        }

        return false;
       
    }
    
    public Vector3 CalculatePursuit(Vector3 target, bool isDynamic, bool arrival)
    {
        Vector3 prevPosition = Vector3.zero;
        Vector3 frameTargetVelocity = Vector3.zero;
        Vector3 futurePos = Vector3.zero;

        Vector3 currentVelocity = (target - prevPosition) / Time.deltaTime;
        frameTargetVelocity = Vector3.Lerp(frameTargetVelocity, currentVelocity, 0.1f);
        prevPosition = target;

        if (isDynamic)
        {
            _T = (target - transform.position).magnitude / _speed;
        }

        futurePos = target + (frameTargetVelocity * _T);

        return CalculateSeek(futurePos, arrival);
    }

    public Vector3 CalculateEvade(Vector3 target, bool isDynamic)
    {
        Vector3 evade = (-1) * CalculatePursuit(target,isDynamic,false);
        return evade;
    }
    public Vector3 CalculateWander(float angle, float distanceC, float radius, bool arrival)
    {
        Vector3 distanceCircle = transform.position + (_velocity.normalized * distanceC);
        Vector3 rotated = Quaternion.AngleAxis(angle, Vector3.forward) * _velocity.normalized;
        Vector3 circleDir = distanceCircle + (rotated * radius);

        return CalculateSeek(circleDir, arrival);
    }


    public void Move(Vector3 steering,bool is3D, bool farAway)
    {
        _velocity = Vector3.ClampMagnitude(_velocity + steering * Time.deltaTime, _speed);

        if (farAway)
        {
            if (CalculateFarAway(_target))
            {
                transform.position += _velocity * Time.deltaTime;
            }
        }
        else
        {
            transform.position += _velocity * Time.deltaTime;
        }
        
        
        
        if (is3D)
        {
            float rotation = Vector3.SignedAngle(Vector3.forward, _desiredVelocity,transform.eulerAngles);
            transform.eulerAngles = new Vector3(0, rotation, 0);
        }
       
    }
}
