using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick_Random_Run : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 randomPos;

    // Start is called before the first frame update
    void Start()
    {
        Random_Position();
        //transform.position = new Vector3(Random.Range(-100.0F, 100.0F), 0.5f, Random.Range(-100.0F, 100.0F));
    }

    void Random_Position()
    {
        randomPos = new Vector3(Random.Range(-50.0F, 50.0F), 0.5f, Random.Range(-50.0F, 50.0F));
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, randomPos, step);

        if (Vector3.Distance(transform.position, randomPos) < 0.001f)
        {
            Random_Position();
        }

    }

    
}
