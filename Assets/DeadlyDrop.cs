using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyDrop : MonoBehaviour
{
    //function that executes when something touches the lake
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        //if the player touches the lake's collider
        {
            FindObjectOfType<LevelManager>().RespawnPlayer();
            //go to the Level Manager script and run RespawnPlayer
        }
    }
}