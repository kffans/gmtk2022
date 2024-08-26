using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
	public const int currentFPS = 60;
	
	public IEnumerator objectFade(Image imageFade, double time, bool isBecomingInvisible){//either Image or RawImage type, maybe even Sprite; time is in seconds
		float alpha = imageFade.color.a*255; //current alpha (transparency) of an object
		float change = Convert.ToSingle(alpha/(time*currentFPS));

		while(alpha>0){
			imageFade.color = new Color32(Convert.ToByte(imageFade.color.r*255), Convert.ToByte(imageFade.color.g*255), Convert.ToByte(imageFade.color.b*255), Convert.ToByte(alpha)); //it keeps the current color, just changes the alpha
			if(isBecomingInvisible==true)
				alpha-=change;
			else
				alpha+=change;
			yield return null;
		}
		
	}
	
	public static IEnumerator objectMove(RectTransform thing, double time, double distance, float angle, int move_type){ //time is in seconds; angle is in degrees
		int num_of_frames=1; //used for increment, to match the time_in_frames
		int time_in_frames=Convert.ToInt32(time*currentFPS);
		
		float delta=0; //the distance an object has to move during one frame
		double a; //some constant used in different move types
		
		float x = 0; //change in x axis, later derived from angle and delta
		float y = 0; //change in y axis, later derived from angle and delta
		while(num_of_frames<=time_in_frames){
			if(move_type==1){
				delta=Convert.ToSingle(distance/time_in_frames);
			}
			if(move_type==2){
				a=(15*distance)/(2*time_in_frames); //don't worry about it
				delta=Convert.ToSingle(((a/(time_in_frames*time_in_frames))*((Math.Pow(num_of_frames,3)/3)-(Math.Pow(num_of_frames,5)/(5*time_in_frames*time_in_frames)))));
				delta-=Convert.ToSingle(((a/(time_in_frames*time_in_frames))*((Math.Pow(num_of_frames-1,3)/3)-(Math.Pow(num_of_frames-1,5)/(5*time_in_frames*time_in_frames)))));
			}
			
			x = Mathf.Cos(angle*Mathf.Deg2Rad) * delta;
			y = Mathf.Sin(angle*Mathf.Deg2Rad) * delta;
			
			thing.position+=new Vector3(x,y,0); //change the position of object
				
			num_of_frames++;
			yield return null;
		}
	}
	
	
	
	// Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = currentFPS;
		//StartCoroutine(objectFade(GameObject.Find("Image").GetComponent<Image>(),1,true));
		//StartCoroutine(objectMove(GameObject.Find("Image_1").GetComponent<RectTransform>(), 10, 1000, 90, 2));
		
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
