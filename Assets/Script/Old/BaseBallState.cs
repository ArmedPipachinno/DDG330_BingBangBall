using UnityEngine;

public abstract class BallStateInitator
{
    public abstract void EnterStage(BallStateManager ball);//(BallStateManager _ballWillDo);

    public abstract void UpdateStage(BallStateManager ball);//BallStateManager _ballDoing);

    public abstract void ExitStage(BallStateManager ball);//(BallStateManager _ballDone);


}
//    public static BallStateInitator Instance;

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
