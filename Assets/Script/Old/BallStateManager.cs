using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine.SceneManagement;

public class BallStateManager : MonoBehaviour
{
    BaseBallState CurrentState;
    public LauncherMovementState MovingState = new LauncherMovementState();
    public AimState AimingState = new AimState();
    public FiringStage FireStage = new FiringStage();


    void Start()
    {
        CurrentState = MovingState;
        CurrentState.EnterStage(this);
    }

    private void Update()
    {
        CurrentState.UpdateStage(this);
    }

    public void SwitchStage(BaseBallState state)
    {
        CurrentState = state;
        state.EnterStage(this);
    }


}
    //[SerializeField] private bool _moveState;
    //[SerializeField] private bool _rotateState;
    //[SerializeField] private bool _LaunchState;

    //[SerializeField] private bool _launched;

    //[SerializeField] private float _launchForce;
    //[SerializeField] private Vector3 _launchDirection;

    //[SerializeField] private Rigidbody _rigidBody;

    //[SerializeField] private FiringStage _launchScript;
    //[SerializeField] private AimState _rotateScript;
    //[SerializeField] private LauncherMovementState _moveScript;


    //private bool RIsPressed = false;
    //private float PressedTimer = 0f;
    //private float KeyHoldRequired = 3f;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    _moveState = true;
    //    _rotateState = true;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (_moveState)
    //    {
    //        _moveScript.MoveBall(true);
    //        _rotateScript.RotateBall(true);
    //        _launchScript.LaunchBall(false);
    //    }

    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //        if (_rotateState)
    //        {
    //            _moveState = false;
    //            _LaunchState = true;

    //            _moveScript.MoveBall(false);
    //            _rotateScript.RotateBall(false);
    //            _launchScript.LaunchBall(true);

    //            _launchDirection = _rotateScript.LaunchAngle * Vector3.forward;
    //        }
    //    }

    //    if (Input.GetKeyUp(KeyCode.Space))
    //    {
    //        if (_LaunchState)
    //        {
    //            _rotateState = false;
    //            _LaunchState = false;

    //            _rotateScript.RotateBall(false);
    //            _rotateScript.AimCanvas(false);

    //            _launchScript.LaunchBall(false);

    //            _launchForce = _launchScript.LaunchForce;

    //            _rigidBody.AddForce(_launchDirection * _launchForce, ForceMode.Impulse);

    //            _launched = true;
    //        }
    //    }

    //    if (_launched)
    //    {
    //        BallStateInitator.Instance.BallLaunched = true;
    //        enabled = false;
    //    }


    //}

    //private void ResetGame()
    //{
    //    if (Input.GetKey(KeyCode.R))
    //    {
    //        // If R key is not already pressed, set the time it was first pressed
    //        if (!RIsPressed)
    //        {
    //            RIsPressed = true;
    //            PressedTimer = Time.time;
    //        }

    //        // Checking the required hold time condition
    //        if (Time.time - PressedTimer >= KeyHoldRequired)
    //        {
    //            Debug.Log("Reset Scene!");
    //            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //        }
    //    }
    //    else
    //    {
    //        RIsPressed = false;
    //    }
        
    //}