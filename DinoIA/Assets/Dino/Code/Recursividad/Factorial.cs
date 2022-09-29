using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factorial : MonoBehaviour
{
    public int factorial;
    void Start()
    {
       Debug.Log( FactorialFunction(factorial));
    }

    int FactorialFunction(int n)
    {
        if (n == 1) return n;
        n = n * FactorialFunction(n - 1);
        return n;
    }
    

        
   
}
