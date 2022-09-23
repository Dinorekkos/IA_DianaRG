using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tarea3Controller : MonoBehaviour
{
    public static Tarea3Controller Instance;
    public int currentPeaked;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] public List<GameObject> collectedObjects;
    [SerializeField] public Queue QueueObjects;
    [SerializeField] public GameObject firstCollectable;
    [SerializeField] public List<CollectableObj_Tarea3> collectablesInScene;
    [SerializeField] public Queue<GameObject> pursuitObjects;
    

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _playerMovement.OnCollectObj += AddCollectableToRow;
        pursuitObjects = new Queue<GameObject>();
        QueueObjects = new Queue();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void AddCollectableToRow(GameObject obj)
    {
        collectedObjects.Add(obj);
        pursuitObjects.Enqueue(obj);
        if (firstCollectable == null)
        {
            firstCollectable = collectedObjects[0];
        }
        currentPeaked = collectedObjects.Count;
        CheckList();
    }

    void CheckList()
    {
        int oneThird = collectablesInScene.Count / 3;
        int twoThird = collectablesInScene.Count / 3 + oneThird;
        
        if (currentPeaked == oneThird)
        {
            for (int i = 0; i < collectablesInScene.Count; i++)
            {
                if (!collectablesInScene[i].isCollected)
                {
                    collectablesInScene[i].isFlee = true;
                }
            }
        }

        if (currentPeaked == twoThird)
        {
            print("entra en pursuirt y evade");
            for (int i = 0; i < collectablesInScene.Count; i++)
            {
                if (collectablesInScene[i].isFlee && !collectablesInScene[i].isCollected)
                {
                    collectablesInScene[i].isFlee = false;
                    collectablesInScene[i].isEvade = true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                CollectableObj_Tarea3 collectable = pursuitObjects.Peek().GetComponent<CollectableObj_Tarea3>();
                collectable.isCollected = false;
                collectable.isPursuit = true;
                pursuitObjects.Dequeue();
            }
            
            GiveNewIndex();
        }
    }
    
    void GiveNewIndex()
    {
        
        firstCollectable = collectedObjects[3];
        
        for (int i = 0; i < collectedObjects.Count + 3; i++)
        {
            CollectableObj_Tarea3 col = collectedObjects[i].GetComponent<CollectableObj_Tarea3>();
            col._indexList = i -1;

        }
        
        

    }
    
}
