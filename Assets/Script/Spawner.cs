using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    public Actionier Sample;
    public int SpawnAmount = 100;
    public float SpawnInterval = 0.2f;
    public float SpawnRadius = 10f;
    
    private BoxPool BPool;
    private ObjectPool<Actionier> UnityPool;

    private void Awake()
    {

        UnityPool = new ObjectPool<Actionier>(() =>
        {
            return Instantiate(Sample);
        },
        box =>
        {
            box.ResetData();
            box.gameObject.SetActive(true);
        },
        box =>
        {
            box.gameObject.SetActive(false);
        },
        box =>
        {
            Destroy(box.gameObject);
        },
        false,
        SpawnAmount * 10,
        10000); 
    }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine() 
    { 
        while (true) 
        { 
            yield return new WaitForSeconds(SpawnInterval);

            for (int i = 0; i < SpawnAmount; i++)
            {
                // ActionExample box = Instantiate(example);
                Actionier spawn = UnityPool.Get();
                spawn.transform.position = transform.position + Random.insideUnitSphere * SpawnRadius;
                spawn.Init(KillBox);
            }
        }
    }

    private void KillBox(Actionier sample)
    {
        UnityPool.Release(sample);
    }
}
