using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Chick_Spwan : MonoBehaviour
{
    public GameObject cube;

    

    // Start is called before the first frame update
    void Start()
    {
        SpawnCube();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void SpawnCube()
    {
        Vector3 position = new Vector3(Random.Range(-10.0F, 10.0F), 1, Random.Range(-10.0F, 10.0F));
        Instantiate(cube, position, Quaternion.identity);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "player")
        {
            Destroy(this.gameObject);
            SpawnCube();

        }
    }
}
