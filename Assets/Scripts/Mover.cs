using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;
    private Rigidbody rigidBody;

	void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = rigidBody.transform.forward * speed;
    }
}
