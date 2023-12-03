using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPool : MonoBehaviour
{
    private Actionier BoxPrefab;

    private Queue<Actionier> BoxCollection = new Queue<Actionier>();

    public BoxPool(Actionier boxPrefab, int initialize)
    {
        boxPrefab = BoxPrefab;

        for (int i = 0; i < initialize; i++) 
        {
            Create();
        }
    }

    private void Create()
    {
        Actionier createBox = Object.Instantiate(BoxPrefab);
        createBox.gameObject.SetActive(false);
        BoxCollection.Enqueue(createBox);
    }

    public Actionier Get() 
    { 
        if (BoxCollection.Count == 0) 
        {
            Create();
        }

        Actionier freebox = BoxCollection.Dequeue();
        freebox.ResetData();
        freebox.gameObject.SetActive(true);

        return freebox;
    }

    public void ReturnToPool(Actionier action) 
    { 
        base.gameObject.SetActive(false);
        BoxCollection.Enqueue(action);
    }
}
