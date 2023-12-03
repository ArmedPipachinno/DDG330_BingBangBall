using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public int CountDur;
    public Action<Action> KillAction;
    private Rigidbody Rb;

    private void Awake()
    {
        TryGetComponent(out Rb);
    }

    private void Start()
    {
        CountAndDO(CountDur, (x) => { Debug.Log($" report {x * 2}"); });
    }

    private void CountAndDO(int duration, System.Action<int> callBack)
    {
        StartCoroutine(CountAndDoCoroutine(duration, callBack));
    }

    private IEnumerator CountAndDoCoroutine(int duration, System.Action<int> callBack)
    {
        int counter = 0;
        while (counter < duration) 
        { 
            yield return new WaitForSeconds(1f);
            counter++;
            callBack?.Invoke(counter);
        }
    }

    public void Init(System.Action<Action> KillAction)
    {
        this.KillAction = KillAction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            KillAction?.Invoke(this);
        }
    }

    public void ResetData()
    {
        Rb.velocity = Vector3.zero;
    }
}