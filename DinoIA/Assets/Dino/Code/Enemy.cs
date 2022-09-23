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
        _target = PlayerMovement.Instance.positionClick;
        
       if(isSeek) Move(CalculateSeek(_target, hasArrival), is3D, false);
       if(isFlee) Move(CalculateFlee(_target), is3D, false);
       
       // if(isPursuit)Move(CalculatePursuit(_target, isPursuitDynamic, hasArrival), is3D, false);
        if(isEvade) Move(CalculateEvade(_target, isPursuitDynamic), is3D, false);
    }
}
