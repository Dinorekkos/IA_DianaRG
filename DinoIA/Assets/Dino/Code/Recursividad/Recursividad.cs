using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class Recursividad : MonoBehaviour
{
    [SerializeField] 
    private MyMethod selectedMethod;
    
    [Header("Factorial")]
    public int factorial;

    [Header("Fibbonacci")] 
    public int fiboNumber;
    
    [Header("Conteo Array")] 
    public int[] array;
    
    [Header("Lista")] 
    public List<int> list;
    
    public void DoRecursive()
    {
        switch (selectedMethod)
        {
            case MyMethod.Factorial:
                Debug.Log( FactorialFunction(factorial));
                break;
            case MyMethod.Fibonacci:
                Debug.Log(Fibonacci(fiboNumber));
                break;
            case MyMethod.ContadorArray:
                Debug.Log(CountArray(array,0));
                break;
                case MyMethod.SumaLista:
                    Debug.Log(CalculateSum(list, 0));
                    break;
        }
    }

    int FactorialFunction(int n)
    {
        if (n == 1) return n;
        n = n * FactorialFunction(n - 1);
        return n;
    }
    
    int Fibonacci( int n)
    {
        if (n < 2) return n;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    int CountArray(int[] a, int index)
    {
        if (index != a.Length) return CountArray(a, index + 1);
        return index;

    }
    
    int CalculateSum(List<int> list, int index)
    {
        if (index != list.Count)
        {
            return list[index] + CalculateSum(list, index + 1);
        }
        return 0;
    }
    
}

[CustomEditor(typeof(Recursividad))]
public class RecursividadEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Recursividad recursividad = target as Recursividad;
            
        if (GUILayout.Button("Do Recursive Method"))
        {
            recursividad.DoRecursive();
        }  
       
    }
}

public enum MyMethod
{
    none, 
    Factorial,
    Fibonacci,
    ContadorArray,
    SumaLista
    
}