using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GraphicsBuffer;

public class BallLauncher : MonoBehaviour
{
    public static BallLauncher Instance;

    private GameObject ballCurrent;
    [SerializeField] private GameObject ChargeBar;
    [SerializeField] private GameObject Ball;
    [SerializeField] private List<GameObject> ballList = new List<GameObject>();

    private bool IsCharge;
    public bool _isCharge => IsCharge;
    private bool IsChargeReverse;
    private bool IsRotateReverse;
    private bool IsDestroyed;

    private float CurAngle = 0;
    private float CurDampSpeed;

    private int SpawnCount;

    [SerializeField] private float BasePower = 200;
    [SerializeField] private float BufferSpeed = 1000;
    [SerializeField] private float MaxRotation = 180;
    [SerializeField] private float RotateTime = 0;
    [SerializeField] private float StopThereshold = 3f;

    private float CurrentBallVelocity;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        Launching();
        ClearBall();

        if (CurAngle >= 90)
        {
            IsRotateReverse = true;
        }

        if (CurAngle <= -90)
        {
            IsRotateReverse = false;
        }

        if (ballCurrent != null)
        {
            CurrentBallVelocity = ballCurrent.GetComponent<Rigidbody>().velocity.magnitude;
            Debug.Log(CurrentBallVelocity);
        }
        else
        {
            CurrentBallVelocity = 0f;
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            CurrentBallVelocity = 0f;
        }
    }

    private void Launching()
    {
        if (CurrentBallVelocity >= StopThereshold) return;

        if (Input.GetKey(KeyCode.Space) && SpawnCount < 5)
        {
            IsCharge = true;

            if (!IsRotateReverse)
            {
                CurAngle = Mathf.SmoothDamp(CurAngle, MaxRotation, ref CurDampSpeed, RotateTime);

            }
            else
            {
                CurAngle = Mathf.SmoothDamp(CurAngle, -MaxRotation, ref CurDampSpeed, RotateTime);
            }

            transform.rotation = Quaternion.Euler(0, CurAngle, 0);


            if (BasePower >= 1000)
            {
                IsChargeReverse = true;
            }
            else if (BasePower <=0)
            {
                IsChargeReverse = false;
            }

            if (!IsChargeReverse)
            {
                BasePower += Time.deltaTime * BufferSpeed;
            }
            else
            {
                BasePower -= Time.deltaTime * BufferSpeed;
            }

            float scale = BasePower / 1000;
            ChargeBar.transform.localScale = new Vector3(2, scale*2, 1);
        }

        if (Input.GetKeyUp(KeyCode.Space) && SpawnCount < 5)
        {
            SpawnCount++;

            ballCurrent = Instantiate(Ball, transform.position, transform.rotation);
            ballCurrent.GetComponent<Rigidbody>().AddForce(transform.forward * BasePower);
            ballList.Add(ballCurrent);

            BasePower = 0;

            IsCharge = false;
            IsChargeReverse = false;

            ChargeBar.transform.localScale = new Vector3(1, 0, 1);
        }
    }

    private void ClearBall()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnCount = 0;

            try
            {
                for (int i = 0; i < ballList.Count; i++)
                {
                    Destroy(ballList[i].gameObject);

                    if (ballList.Count - i <= 2)
                    {
                        IsDestroyed = true;
                    }
                }
            }
            catch
            {
                return;
            }

            if (IsDestroyed)
            {
                ballList.Clear();
            }
        }
    }
}