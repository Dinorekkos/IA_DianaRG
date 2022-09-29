using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public SpriteRenderer _renderer;
    public bool isRed;
    public bool isGreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor()
    {
        if(CheckCurrentColor()) return; 
        _renderer.color = Color.red;
        isRed = true;
    }

    public void SetGreen()
    {
        _renderer.color = Color.green;
        isGreen = true;
    }

    private bool CheckCurrentColor()
    {
        if (isRed)
        {
            return true;
        }

        return false;
    }
}
