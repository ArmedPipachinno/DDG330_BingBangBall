using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private GameObject PointerArrow;
    [SerializeField] private GameObject SideArrow;

    void Update()
    {
        if (BallLauncher.Instance._isCharge)
        {
            SideArrow.SetActive(true);
            PointerArrow.SetActive(false);
        }
        else
        {
            PointerArrow.SetActive(true);
            SideArrow.SetActive(false);
        }
    }
}