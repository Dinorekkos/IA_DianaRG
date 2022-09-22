using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObj_Tarea3 : SteerinngBehaviors
{
    
    void Start()
    {
        
    }

    void Update()
    {
        // HandleFollowLeader();
    }


    void HandleFollowLeader()
    {
        List<GameObject> collectables = Tarea3Controller.Instance.collectables;

        
        if (collectables.Count == 1)
        {
            // _target = 
            // Move(CalculateSeek(_target, false), false,false);
        }
        // if (collectables.Count != 0 && collectables.Count >=2)
        // {
            // _target = collectables[collectables.Count - 1].transform.position;
            // Move(CalculateSeek(_target, false), false,false);
        // }
        
    }
}
