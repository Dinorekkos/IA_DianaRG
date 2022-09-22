using System.Collections;
using UnityEngine;

public class NPC_Wander : SteerinngBehaviors
{
    [Header("NPC")]
    public GameObject circle;
    public float distanceCircle;
    public float radius = 1;
    public Vector3 wanderDirection;
    
    public float wanderAngle;

    

    void Start()
    {
        wanderAngle = Random.Range(-180, 180);
        StartCoroutine(UpdateTarget());
        
    }

    void Update()
    {
        Vector3 wander = CalculateWander(wanderAngle, distanceCircle, radius, false);
        Vector3 seek = CalculateSeek(_target, false);
        wanderDirection = wander + seek;
        Move(wanderDirection, true, false);
        circle.transform.position = transform.position + (_velocity.normalized * distanceCircle);
    }

    IEnumerator UpdateTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            wanderAngle = Random.Range(-180, 180);
        }
        
    }

    
    
    
}
