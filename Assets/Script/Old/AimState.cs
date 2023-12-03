using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimState : BaseBallState
{

    override public void EnterStage(BallStateManager _ballWillDo)
    {
        Debug.Log("Start moivng");
    }

    override public void UpdateStage(BallStateManager _ballDoing)
    {
        Debug.Log("Aiming");
    }

    override public void ExitStage(BallStateManager _ballDone)
    {
        Debug.Log("Start moivng");
    }

}

//    [SerializeField] private float _minAngle = -40f;
//    [SerializeField] private float _maxAngle = 40f;
//    [SerializeField] private float _rotateSpeed;
//    [SerializeField] private Quaternion _launchAngle;

//    [SerializeField] private GameObject _arrowPivot;

//    private float _currentAngle;

//    public Quaternion LaunchAngle => _launchAngle;

//    void Start()
//    {
//        _currentAngle = _minAngle;

//        AimCanvas(true);
//    }

//    public void RotateBall(bool activate)
//    {
//        if (activate)
//        {
//            _arrowPivot.SetActive(activate);

//            _currentAngle = Mathf.Lerp(_minAngle, _maxAngle, Mathf.PingPong(Time.time * _rotateSpeed, 1));

//            _launchAngle = Quaternion.Euler(0, _currentAngle, 0);

//            _arrowPivot.transform.rotation = _launchAngle;
//        }
//    }

//    public void AimCanvas(bool activate)
//    {
//        _arrowPivot.SetActive(activate);
//    }
//}
