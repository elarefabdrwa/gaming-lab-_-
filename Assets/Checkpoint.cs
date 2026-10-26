using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        //if the player touches the checkpoint's circle collider
        {
            FindObjectOfType<LevelManager>().CurrentCheckpoint = this.gameObject;
            //update CurrentCheckpoint in the Level Manager to this checkpoint
        }
    }
}