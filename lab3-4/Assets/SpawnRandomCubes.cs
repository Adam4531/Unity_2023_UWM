using System;
using System.Collections.Generic;
using UnityEngine;
public class InstantiationExample : MonoBehaviour
{
    public GameObject cube;
    private int iter;
    private Vector3[] list;
    void Start()
    {
        iter = 0;
        list = new Vector3[10];
    }
    bool contains(Vector3[] list, Vector3 vec)
    {
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i] == vec)
            {
                return true;
            }
        }
        return false;
    }
    void Update()
    {
        float pos_x = UnityEngine.Random.Range(1, 9);
        float pos_z = UnityEngine.Random.Range(1, 9);
        float pos_y = 0;
        Vector3 vec = new Vector3(pos_x, pos_y, pos_z);
        if (iter < list.Length && !contains(list, vec))
        {
            list[iter] = vec;
            Instantiate(cube, vec, Quaternion.identity);
            iter++;
        }
    }
}