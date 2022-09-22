using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarea3Controller : MonoBehaviour
{
    public static Tarea3Controller Instance;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] public List<GameObject> collectables;
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _playerMovement.OnCollectObj += AddCollectableToRow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddCollectableToRow(GameObject obj)
    {
        collectables.Add(obj);
    }
    
}
