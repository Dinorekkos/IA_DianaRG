using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Palindrome : MonoBehaviour
{
    // Fields
    private int _size;
    private int _count;
    private string _palindrome;
    private bool _value;
    private bool _isPalindrome;
    private Stack<string> revert = new Stack<string>();
    
    public string _input;
    public int _index;


    // Properties
    public string palindrome { 
        get { return _palindrome; }
        set {
            if (string.IsNullOrEmpty(value))
            {
                Debug.LogError("No se admiten strings vacios");
            }
            _palindrome = value; 
        }        
    }

    public int Count
    {
        get 
        {
            Revert(0);
            return CountPalindrome(0, 0);
        }
    }

    public bool Value
    {
        get { return isPalindrome(); }
    }

    private int CountPalindrome(int count, int index)
    {
        if (index != _size) 
        {
            string letter = revert.Pop();

            if (letter == _palindrome[index].ToString())
            {
                count++;
                
            }
            CountPalindrome(count, index + 1);
            
        }

        return count;
    }
    
  
    public string Show()
    {
        return palindrome;
    }

    public bool isPalindrome()
    {
        Revert(0);
        _isPalindrome = true;
        CheckPalindrome(0);        
        return _isPalindrome;
    }
    
    public void Start()
    {
        _palindrome = _input;
        _size = palindrome.Length;
    }

    void Revert(int i)
    {
        if (i == _size) return;
        revert.Push(_palindrome[i].ToString());
        Revert(i + 1);
    }

    void CheckPalindrome(int i)
    {
        if (i == _size) return;
        string letter = revert.Pop();
        if (letter != _palindrome[i].ToString())
        {
            _isPalindrome = false;
        }
        CheckPalindrome(i + 1);
    }

    public void New(string p)
    {
        if (string.IsNullOrEmpty(p))
        {
            Debug.LogError("No se admiten strings vacios");
        }
        _palindrome = p;
    }
    
    public void Remove(int index, int toErase, string letterToRemove, string p)
    {
        if (index == _size)
        {
            palindrome = p;
            return;
        }
        if (index == toErase)
        {
            letterToRemove = _palindrome[index].ToString();
            print(letterToRemove);
        }
        if (_palindrome[index].ToString() != letterToRemove)
        {
            p += _palindrome[index].ToString();
        }
       
        Remove(index + 1, toErase, letterToRemove, p);
    }
   
   
    public void AddIndex(string letterToAdd)
    {
        Revert(0);
        Add(0, letterToAdd, "");
    }
    private void Add(int index, string letter , string p)
    {
        if (index == _size)
        {
            p += revert.Pop();
            p += letter;
            palindrome = p;
            return;
        }
        if (index == 0)
        {
            revert.Push(letter);
        }
        
        p += revert.Pop();
        Add(index + 1, letter, p);
    }

    public void Multiply(int times, int index)
    {
        if (times != index)
        {
            _palindrome += _palindrome;
            _size = _palindrome.Length;
        
            Multiply(times, index + 1);
        }
    }
    
}


[CustomEditor(typeof(Palindrome))]
public class PalindromeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Palindrome myScript = (Palindrome)target;
        
        if (GUILayout.Button("Is Palindrome"))
        {
            myScript.Start();   
            Debug.Log(myScript.isPalindrome());
        }
       
        if (GUILayout.Button("New Palindrome"))
        {
            myScript.Start();
            myScript.New(myScript.palindrome);
            Debug.Log(myScript.Show());
            
        }
        if (GUILayout.Button("Show Palindrome"))
        {
            myScript.Start();
            Debug.Log(myScript.Show());
        }

        if (GUILayout.Button("Remove"))
        {
            myScript.Start();
            myScript.Remove(0, myScript._index, "", "");
            Debug.Log(myScript.Show());
        }
        
        if(GUILayout.Button("Multiply"))
        {
            myScript.Start();
            myScript.Multiply(myScript._index, 0);
            Debug.Log(myScript.Show());
        }

        if (GUILayout.Button("Count"))
        {
            myScript.Start();
            Debug.Log(myScript.Count);
        }

        if (GUILayout.Button("Add"))
        {
            myScript.Start();
            myScript.AddIndex("a");
            Debug.Log(myScript.Show());
        }
       
    }
}
