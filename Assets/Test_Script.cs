using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class Test_Script: MonoBehaviour
{
    [Header("Points")]
    public Vector3[] hitPoints_Array;
    public int no_of_Hit;

    
    
    [Header("GameObjects")]
    public GameObject spawn_object;
    private GameObject laser_Hit_Point;
    private List<GameObject> LastFrameInstantiations;



    private void Awake()
    {

    }

    
        

    public void Clear()
    {
        foreach (GameObject x in LastFrameInstantiations)
        {
            Destroy(x);
        }
        LastFrameInstantiations.Clear();
    }

    private void Update()
    {
        //if (LastFrameInstantiations != null)
        //{
        //    foreach (GameObject x in LastFrameInstantiations)
        //    {
        //        Destroy(x);
        //    }
        //    LastFrameInstantiations.Clear();
        //}            

        

    }
}