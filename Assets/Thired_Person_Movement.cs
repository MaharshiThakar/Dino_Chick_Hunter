using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thired_Person_Movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;

    private Rigidbody P_Rigidbody;
    public float P_Thrust = 20f;

    public float turnSmoothTime = 0.1f;

    public int spwan_No;
    private int temp = 2;

    public bool isGrounded;


    public GameObject cube;

    private float turnSmoothVelocity;

    private void Awake()
    {
        SpawnCube();
        P_Rigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown("space") && isGrounded)
        {
            Debug.Log("Space down");
            //P_Rigidbody.constraints = RigidbodyConstraints.None;
            P_Rigidbody.AddForce(transform.up * P_Thrust);
        }

        if (Input.GetKeyUp("space"))
        {
            //P_Rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            Debug.Log("Space up");
        }

    }

    public void SpawnCube()
    {
        //spwan_No++;
        temp++;

        if (temp % 3 == 0)
        {
            spwan_No++;
        }


        for(int i = 0; i <= spwan_No; i++)
        {
            Vector3 position = new Vector3(Random.Range(-50.0F, 50.0F), 0.5f, Random.Range(-50.0F, 50.0F));
            Instantiate(cube, position, Quaternion.identity);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Chick")
        {
            //Debug.Log("Hit");
            Destroy(collision.gameObject);
            SpawnCube();
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Chick"))
    //    {
    //        Debug.Log("Hit");
    //        Destroy(Collision.);
    //        SpawnCube();

    //    }

    //}

}
