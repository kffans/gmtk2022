using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameplayManager mng;
	void Start()
    {
        GameplayManager.destroyObjects=true;
    }
	
	public void returnMenu(){
		SceneManager.LoadScene("menu");
	}
}
