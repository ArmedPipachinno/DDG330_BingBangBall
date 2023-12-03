using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class LauncherMovement : MonoBehaviour
{
    private float MovementXAxis;
    private Rigidbody Launcher;
    public Vector3 RawMovement { get; private set; }

    [SerializeField] private float Speed = 10;
    [SerializeField] private float Accel = 90;
    [SerializeField] private float Decel = 60f;
    private float CurtHorSpd;

    void Start()
    {
        Launcher = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        LauncherInput();
        MovementCalculation();
        Movement(RawMovement);
    }

    private void LauncherInput()
    {
        MovementXAxis = Input.GetAxis("Horizontal");
    }

    private void MovementCalculation()
    {
        if (BallLauncher.Instance._isCharge)
        {
            Launcher.constraints = RigidbodyConstraints.FreezePositionX;
        }
        else
        {
            Launcher.constraints = RigidbodyConstraints.None;

            if (MovementXAxis != 0)
            {
                CurtHorSpd += MovementXAxis * Accel * Time.deltaTime;
                CurtHorSpd = Mathf.Clamp(CurtHorSpd, -Speed, Speed);
            }
            else
            {
                CurtHorSpd = Mathf.MoveTowards(CurtHorSpd, 0, Decel * Time.deltaTime);
            }
        }
    }

    private void Movement(Vector3 move)
    {
        RawMovement = new Vector3(CurtHorSpd, 0, 0);
        move = RawMovement * Time.deltaTime;

        Launcher.MovePosition(Launcher.position + (Vector3)move);
    }
}