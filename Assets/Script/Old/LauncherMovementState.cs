using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherMovementState : BaseBallState
{
    //[SerializeField] private Rigidbody RigidBody;

    [SerializeField] private float MoveSpeed = 0;
    [SerializeField] private float MinMove = -6f;
    [SerializeField] private float MaxMove = 6f;

    private bool CanMove = false;

    //float horizontalInput = Input.GetAxisRaw("Horizontal");

    public override void EnterStage(BallStateManager _ballWillDo)
    {
        Debug.Log("Start moivng");
        CanMove = true;
        //rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    override public void UpdateStage(BallStateManager _ballDoing)
    {
        if (CanMove) 
        {

            //Debug.Log("Is moivng");
            //if (Input.GetKey(KeyCode.A))
            //{
            //    _ballDoing.transform.position += -Vector3.right * MoveSpeed * Time.deltaTime;
            //    //Ball.transform.Translate(Vector3.left * Ball._Speed * Time.deltaTime);
            //}
            //if (Input.GetKey(KeyCode.D))
            //{
            //    _ballDoing.transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
            //}

            //float clampedLength = Mathf.Clamp(_ballDoing.transform.position.x, MinMove, MaxMove);
            //_ballDoing.transform.position = new Vector3(clampedLength, _ballDoing.transform.position.y, _ballDoing.transform.position.z);
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) 
        {
            CanMove = false;
            _ballDoing.SwitchStage(_ballDoing.AimingState);
        }
        
    }

    override public void ExitStage(BallStateManager _ballDone)
    {
        Debug.Log("Stop moivng");

    }

}

//    [SerializeField] private float _moveSpeed = 0;
//    [SerializeField] private float _minLength;
//    [SerializeField] private float _maxLength;

//    [SerializeField] private GameObject _canvas;

//    public void MoveBall(bool activate)
//    {
//        _canvas.SetActive(activate);

//        if (activate)
//        {
//            if (Input.GetKey(KeyCode.A))
//            {
//                transform.position += -Vector3.right * _moveSpeed * Time.deltaTime;
//            }
//            if (Input.GetKey(KeyCode.D))
//            {
//                transform.position += Vector3.right * _moveSpeed * Time.deltaTime;
//            }

//            float clampedLength = Mathf.Clamp(transform.position.x, _minLength, _maxLength);
//            transform.position = new Vector3(clampedLength, transform.position.y, transform.position.z);
//        }
//    }
//}
