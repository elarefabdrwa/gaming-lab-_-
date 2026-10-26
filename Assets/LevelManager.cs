using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckpoint; //so we can update the current checkpoint from within Unity

    // Use this for initialization
    void Start()
    {
        CurrentCheckpoint = null;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RespawnPlayer()
    {
        FindObjectOfType<PlayerController>().transform.position = CurrentCheckpoint.transform.position;
        //Find the player's script, then move the player to the last checkpoint he passed
    }
}