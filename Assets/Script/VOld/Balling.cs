using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balling : MonoBehaviour
{
    [field:SerializeField] Rigidbody BallRigid;
    [field: SerializeField] GameObject Ball;
    float ArrowDirections = 0.0f;
    float BallForce = 1.0f;

    [SerializeField] float CapL = -45f;
    [SerializeField] float CapR = 45f; 

    [field: SerializeField] Rigidbody Point;

    private void Start()
    {
        //Ball = GetComponent<GameObject>();
        //BallRigid = GetComponent<Rigidbody>();
        //Point = GetComponent<Rigidbody>();
        ArrowDirections = transform.eulerAngles.z; 
    }
    private void Update()
    {
        BallLaunch();
    }

    void BallLaunch()
    {
        float HI = Input.GetAxis("Horizontal");
        float Angle = HI * Mathf.Rad2Deg;
        float ClampAngle = Mathf.Clamp(Angle, CapL, CapR);

        transform.eulerAngles = new Vector3(0, ArrowDirections + ClampAngle, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 BallDirection = new Vector3(Angle,0, Angle);
            BallRigid.AddForce(BallDirection * BallForce, ForceMode.Impulse);
        }
    }

}
