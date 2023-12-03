using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    public static ScoreDisplay Instance;

    [SerializeField] private TMP_Text ScoreText;
    public List<ScoreZone> BallList = new List<ScoreZone>();
    public int[] Values = new int[0];
    public int SummaryScore;

    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            BallList.Clear();
            SummaryScore = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        Values = new int[BallList.Count];

        if (BallList != null)
        {
            for (int i = 0; i < BallList.Count; i++)
            {
                Values[i] = BallList[i].Score;
            }
        }

        SummaryScore = Values.Sum();

        ScoreText.SetText("Score:" + SummaryScore);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            RegisterBall(other.gameObject);
        }

        Debug.Log(gameObject.name + "Activated");
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Ball"))
        {
            UnRegisterBall(other.gameObject);
        }
    }

    private void RegisterBall(GameObject ballObject)
    {
        if (!ballObject.TryGetComponent(out ScoreZone ballDetector)) return;
        if (BallList.Contains(ballDetector)) return;
        BallList.Add(ballDetector);
    }

    private void UnRegisterBall(GameObject ballObject)
    {
        if (!ballObject.TryGetComponent(out ScoreZone ballDetector)) return;
        BallList.Remove(ballDetector);
    }
}