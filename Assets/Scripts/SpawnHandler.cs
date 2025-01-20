using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int NumPrefabs = 4;
    [SerializeField] List<float> xList = new List<float>();
    [SerializeField] List<float> yList = new List<float>();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
