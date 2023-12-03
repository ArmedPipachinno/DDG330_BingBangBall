using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScore : MonoBehaviour
{
    [SerializeField] private int scoreNumber;

    private MeshRenderer _mesh;

    private void Start()
    {
        _mesh = transform.GetComponent<MeshRenderer>();
        _mesh.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameScoreManager.Instance._CurrentScore += scoreNumber;
    }

    private void OnTriggerExit(Collider other)
    {
        GameScoreManager.Instance._CurrentScore -= scoreNumber;
    }
}
