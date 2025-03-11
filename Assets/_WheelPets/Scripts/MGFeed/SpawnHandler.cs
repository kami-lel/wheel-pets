using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public int NumPrefabs = 4;
    [SerializeField] List<float> xList = new List<float>();
    [SerializeField] List<float> yList = new List<float>();
    [SerializeField] public List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField] GameObject Canvas;
    private List<GameObject> Instans = new List<GameObject>();
    void Start()
    {
        List<int> array = new List<int>(new int[NumPrefabs]);
        for (int i = 0; i < NumPrefabs; i += 1)
        {
            array[i] = i;
        }
        for(int i = 0; i < NumPrefabs; i += 1)
        {
            int j = array[Random.Range(0, NumPrefabs-i)];
            Instans.Add(Instantiate(gameObjects[j], new Vector3(xList[i], yList[i], 0), Quaternion.identity));
            Instans[i].transform.parent = Canvas.transform;
            array.Remove(j);
        }
    }

    // Update is called once per frame

    public void ResetFoods()
    {
        List<int> array = new List<int>(new int[NumPrefabs]);
        for (int i = 0; i < NumPrefabs; i += 1)
        {
            array[i] = i;
            Destroy(Instans[i]);
        }
        Instans.Clear();
        for (int i = 0; i < NumPrefabs; i += 1)
        {
            int j = array[Random.Range(0, NumPrefabs - i)];
            Instans.Add(Instantiate(gameObjects[j], new Vector3(xList[i], yList[i], 0), Quaternion.identity));
            Instans[i].transform.parent = Canvas.transform;
            array.Remove(j);
        }
    }
}
