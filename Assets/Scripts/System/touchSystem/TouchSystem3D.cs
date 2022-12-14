using UnityEngine;
using System.Collections;
namespace game_core{
/// <summary>
/// Touch system3d(Vector3) class; Deals with the hits on the screen.
/// </summary>
public class TouchSystem3D : MonoBehaviour {

	/// <summary>
	/// Layer mask name for example input.
	/// </summary>
	public 	LayerMask 	touchInputMask;
	public	Camera		cam;

	/// <summary>
	///RAYCASTHIT is the structure used to 
	///get information back from a raycast 
	/// </summary>
	private RaycastHit hit;
	
	/// <summary>
	/// WHAT IS RAYCAST? Well,  
	///	Raycast  is used to tell you what objects in the environment the ray 
	///	runs into. (http://answers.unity3d.com/questions/53013/what-is-raycast-use-of-it.html) thanks!!!
	///	In this case is used to know if some "INPUT" has been touched/Clicked.
	/// </summary>
	void Start()
	{
		if(!cam){cam=Camera.main;}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//MOUSE SECTION: HERE IS DETECTED WHEN SOME BOXCOLLIDER IS CLICKED
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			
			if(Physics.Raycast(ray,out hit, touchInputMask))
			{
				GameObject recipient=hit.transform.gameObject;
				if(Input.GetMouseButtonDown(0))
				{
					recipient.SendMessage ("OnTouchBegan",hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
		
		//TOUCH SECTION: HERE IS DETECTED WHEN SOME BOXCOLLIDER IS TOUCHED
		if (Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) 
			{
				Ray ray = cam.ScreenPointToRay (touch.position);
				
				if(Physics.Raycast(ray,out hit, touchInputMask))
				{
					GameObject recipient=hit.transform.gameObject;
					if(touch.phase==TouchPhase.Began || touch.phase==TouchPhase.Stationary)
					{
						recipient.SendMessage ("OnTouchBegan",hit.point, SendMessageOptions.DontRequireReceiver);
					}
				}
			}
		}
		
	}
}
}