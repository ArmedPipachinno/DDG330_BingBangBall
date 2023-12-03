using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBallState
{
    public abstract void EnterStage(BallStateManager _ballWillDo);

    public abstract void UpdateStage(BallStateManager _ballDoing);

    public abstract void ExitStage(BallStateManager _ballDone);

}

//    public static BaseBallState Instance;

//    [SerializeField] public bool BallLaunched;

//    [SerializeField] private BallSummon _BallSummonScript;

//    private void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            Destroy(gameObject);
//        }

//        _BallSummonScript = FindObjectOfType<BallSummon>();
//    }


//    private void OnLevelWasLoaded(int level)
//    {
//        _BallSummonScript = FindObjectOfType<BallSummon>();
//    }

//    void Update()
//    {
//        if (BallLaunched)
//        {
//            _BallSummonScript.spawned = false;
//            BallLaunched = false;
//        }
//    }
//}
