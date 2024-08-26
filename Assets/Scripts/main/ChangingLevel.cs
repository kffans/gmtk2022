using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangingLevel : MonoBehaviour
{
    // Added For changing Level by Chazar
    public GameObject Enemy1;
    public GameObject Enemy2;
    private int SlayedEnemies = 0;
    public int ActualLevel;
    public GameObject Gate;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Enemy1 == null && Enemy2 == null)
        {
            Gate.SetActive(true);
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<Collider>().name == "Gate")
        {
            SceneManager.LoadScene(ActualLevel+1);
        }
    }
    
}
