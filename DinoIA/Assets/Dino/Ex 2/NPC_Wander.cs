using System.Collections;
using UnityEngine;

public class NPC_Wander : SteerinngBehaviors
{
    [Header("NPC")]
    public GameObject circle;
    public float distanceCircle;
    public float radius = 1;
    public Vector3 wanderDirection;
    
    public Vector3 randomTarget;
    public float wanderAngle;

    

    void Start()
    {
        wanderAngle = Random.Range(-180, 180);
        StartCoroutine(UpdateTarget());
        
    }

    void Update()
    {
        Vector3 wander = CalculateWander(wanderAngle, distanceCircle, radius);
        Vector3 seek = CalculateSeek(Target.position);
        wanderDirection = wander + seek;
        Move(wanderDirection);
        circle.transform.position = transform.position + (velocity.normalized * distanceCircle);
    }

    IEnumerator UpdateTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            wanderAngle = Random.Range(-180, 180);
        }
        
    }

    // void CalculateSeek(Vector3 posTarget)
    // {
    //     Vector3 distanceVel = posTarget - transform.position;
    //     Vector3 desiredVel = distanceVel.normalized * speed;
    //     Vector3 steering = desiredVel - velocity;
    //     velocity += steering * Time.deltaTime;
    //     transform.position += velocity * Time.deltaTime;
    // }
    
    
    // void Wander()
    // {
    //     Vector3 distanceCircle = velocity.normalized * distanceC;
    //     Vector3 radiusV = distanceCircle + (velocity.normalized * radius);
    //     
    //     Vector3 steering = distanceCircle + radiusV;
    //
    //     velocity += steering * Time.deltaTime;
    //     transform.position += velocity * Time.deltaTime;
    //
    //     circle.transform.position = transform.position + (velocity.normalized * distanceC);
    //     
    //    
    //
    // }
    
    
    
}
