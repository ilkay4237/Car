using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopSpawn : MonoBehaviour
{
    public GameObject[] ObjectsToSpawn;
    void Start()
    {
        InvokeRepeating("spawn", 4, 1);
    }

    Vector3 GetRandomPos()
    {
        float _x = Random.Range(-20, 20);
        float _y = 1.07f;
        float _z = Random.Range(-20, 20);

        Vector3 newPos = new Vector3(_x, _y, _z);
        return newPos;

    }
    void spawn()
    {
        Instantiate(ObjectsToSpawn[Random.Range(0,1)], GetRandomPos(), Quaternion.identity);
    }
}
