using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    void Awake()
    {
        GameObject.Find("player").transform.position = transform.position;
        
    }
}
