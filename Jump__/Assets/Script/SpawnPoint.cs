using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
   [SerializeField] private GameObject player;
   [SerializeField] private GameObject[] spawnPos;

   private void Awake()
   {
      Instantiate(player, transform.position, Quaternion.identity);
   }

   public Vector3 ReSpawn(int number)
   {
      return spawnPos[number].transform.position;
   }
}
