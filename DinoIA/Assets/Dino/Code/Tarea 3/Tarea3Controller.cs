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
            for (int i = 0; i < 2; i++)
            {
                CollectableObj_Tarea3 collectable = pursuitObjects.Peek().GetComponent<CollectableObj_Tarea3>();
                collectable.isCollected = false;
                collectable.isPursuit = true;
                pursuitObjects.Dequeue();

            }
            collectedObjects.Remove(collectedObjects[0]);
            collectedObjects.Remove(collectedObjects[1]);
            collectedObjects.Remove(collectedObjects[2]);
            GiveNewIndex();
            // print(collectable.name);
        }
        
        
    }
    
    void GiveNewIndex()
    {
        // foreach (var gameObject in collectedObjects)
        // {
        //     CollectableObj_Tarea3 col = gameObject.GetComponent<CollectableObj_Tarea3>();
        //     col._indexList = collectedObjects.Count;
        // }
        firstCollectable = collectedObjects[0];
        
        for (int i = 0; i < collectedObjects.Count -1; i++)
        {
            CollectableObj_Tarea3 col = collectedObjects[i].GetComponent<CollectableObj_Tarea3>();
            col._indexList = i;

        }
        
        

    }
    
}
