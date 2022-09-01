using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public GameObject circle;
    public Vector3 randomTarget;
    public Vector3 velocity ;
    public float distanceC = 2;
    public float radius = 2;
    public float speed = 1;
    void Start()
    {
        velocity = Vector3.zero;
        randomTarget = new Vector3(Random.Range(-8f, 8f), 1, Random.Range(-5f, 5f));
        StartCoroutine(UpdateTarget());
        
    }

    void Update()
    {
        Seek(randomTarget);
        Wander();
    }

    IEnumerator UpdateTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            randomTarget = new Vector3(Random.Range(-4f, 4f), 1, Random.Range(-2f, 2f));
        }
        
    }

    void Seek(Vector3 posTarget)
    {
        Vector3 distanceVel = posTarget - transform.position;
        Vector3 desiredVel = distanceVel.normalized * speed;
        Vector3 steering = desiredVel - velocity;
        velocity += steering * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
    
    
    void Wander()
    {
        Vector3 distanceCircle = velocity.normalized * distanceC;
        Vector3 radiusV = distanceCircle + (velocity.normalized * radius);
        
        Vector3 steering = distanceCircle + radiusV;

        velocity += steering * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        circle.transform.position = transform.position + (velocity.normalized * distanceC);
        
       

    }
    
    
    
}
