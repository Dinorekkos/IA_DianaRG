using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public SpriteRenderer _renderer;
    public bool isRed;
    public bool isGreen;

    public void ChangeColor()
    {
        if(CheckCurrentColor()) return; 
        _renderer.color = Color.red;
        isRed = true;
    }

    public void SetGreen()
    {
        if(CheckCurrentColor()) return;
        _renderer.color = Color.green;
        isGreen = true;
    }

    private bool CheckCurrentColor()
    {
        if (isRed || isGreen) return true;
        
        return false;
    }
}
