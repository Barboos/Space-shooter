using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundry
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController1 : MonoBehaviour {

    public float speed;
    public float tilt;
    public Boundry boundry;

    private Rigidbody rigidBody;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + nextFire;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);  
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidBody.velocity = movement * speed;
        rigidBody.position = new Vector3
        (
            Mathf.Clamp(rigidBody.position.x, boundry.xMin, boundry.xMax),
            0.0f,
            Mathf.Clamp(rigidBody.position.z, boundry.zMin, boundry.zMax)
        );
        rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x * -tilt);
    }
}
