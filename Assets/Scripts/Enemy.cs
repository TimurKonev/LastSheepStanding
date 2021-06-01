using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
   [SerializeField] private float speed;
   [SerializeField] private float waitTime;
   [SerializeField] private float startWaitTime;
   public static int count = 0;
   
   [SerializeField] private float minX;
   [SerializeField] private float maxX;
   [SerializeField] private float minZ;
   [SerializeField] private float maxZ;
   private Rigidbody rigidBody;
   private Vector3 moveSpot;

   private void Awake()
   {
      count++;
   }

   private void Start()
   {
      rigidBody = GetComponent<Rigidbody>();
      waitTime = startWaitTime;

      MoveEnemy();
   }

   private void MoveEnemy()
   {
      moveSpot = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
      transform.LookAt(moveSpot);
   }

   private void Update()
   {
      rigidBody.transform.position = Vector3.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);
      float stoppingDistance = Vector3.Distance(transform.position, moveSpot);

      if (stoppingDistance < 0.2f)
      {
         if (waitTime <= 0)
         {
            MoveEnemy();
            waitTime = startWaitTime;
         }
         else
         {
            waitTime -= Time.deltaTime;
         }
      }
   }
}

