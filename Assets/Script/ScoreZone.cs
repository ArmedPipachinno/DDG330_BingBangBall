using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class ScoreZone : MonoBehaviour
{
    private SphereCollider Collider;
    private Rigidbody Rigid;

    [SerializeField]
    public int Score;
    public bool isSet = false;
    [SerializeField] private List<ZoneData> contacts = new List<ZoneData>();
    [SerializeField] private PhysicMaterial physicMaterial;
    [SerializeField] private PhysicMaterial baseMaterial;
    [SerializeField] private float dragFactor = 0.6f;
    [SerializeField] private float massFactor = 0.1f;


    void Start()
    {
        Score = 0;

        Collider = gameObject.GetComponent<SphereCollider>();
        Rigid = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Score = GetScore();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zone1"))
        {
            contacts.Add(new ZoneData(1, 1, other.gameObject));
        }
        
        if (other.gameObject.CompareTag("Zone2"))
        {
            contacts.Add(new ZoneData(2, 2, other.gameObject));
        }
        
        if (other.gameObject.CompareTag("Zone3"))
        {
            contacts.Add(new ZoneData(3, 3, other.gameObject));
        }

        if (other.gameObject.CompareTag("Slime"))
        {
            Rigid.drag = dragFactor;
        }

        if (other.gameObject.CompareTag("Boost"))
        {
            Rigid.drag = 0.0f;
            Rigid.mass = massFactor;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        contacts.RemoveAll(z => z.ZoneType == other.gameObject);

        if (other.gameObject.CompareTag("Slime"))
        {
            Rigid.drag = 0.3f;
        }

        if (other.gameObject.CompareTag("Boost"))
        {
            Rigid.drag = 0.0f;
            Rigid.mass = 2;
        }
    }

    public int GetScore()
    {
        return contacts.OrderByDescending(z => z.OrderId).FirstOrDefault().ScoreValue;
    }
}