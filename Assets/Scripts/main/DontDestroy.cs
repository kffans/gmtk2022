using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private GameplayManager mng;
	
	void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
	
	void Update()
	{
		if(GameplayManager.destroyObjects==true){
			Destroy(gameObject);
		}
	}
	

}
