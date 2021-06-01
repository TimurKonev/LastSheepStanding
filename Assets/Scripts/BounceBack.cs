using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBack : MonoBehaviour
{
    [SerializeField] private float bounceForce;
    [SerializeField] private float thrustForce;


    private Rigidbody rigidBody;

    private Rigidbody playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = FindObjectOfType<Player>().GetComponent<Rigidbody>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerRigidBody.AddExplosionForce(bounceForce, other.GetContact(0).point, 5);
            rigidBody.AddForce(transform.position * thrustForce);            

        }
    }
}
