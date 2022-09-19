using UnityEngine;

public class Enemy : SteerinngBehaviors
{
    [Header("Enemy Class")]
    public bool isPursuitDynamic;
    public bool is3D;
    public bool hasArrival;
    public bool isSeek;
    public bool isFlee;
    public bool isPursuit;
    public bool isEvade;

    private void Start()
    {
    }

    void Update()
    {
       if(isSeek) Move(CalculateSeek(_target.position, hasArrival), is3D);
       if(isFlee) Move(CalculateFlee(_target.position), is3D);
       
       if(isPursuit)Move(CalculatePursuit(_target.position, isPursuitDynamic, hasArrival), is3D);
        if(isEvade) Move(CalculateEvade(_target.position, isPursuitDynamic), is3D);
    }
}
