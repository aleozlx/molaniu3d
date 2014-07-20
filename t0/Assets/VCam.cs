using UnityEngine;
using System.Collections;

public class VCam : MonoBehaviour {
	bool EN_help;

	void Start () {
		EN_help = false;
	}

	void Update () {
		transform.Translate(Input.GetAxis ("Horizontal"),0,Input.GetAxis ("Vertical"));
		transform.Translate(0,0,6f*Input.GetAxis("Mouse ScrollWheel"));
		if (Input.GetMouseButton (0))
			transform.Rotate(4f*Input.GetAxis("Mouse Y"),-4f*Input.GetAxis ("Mouse X"),0);

		if (Input.GetMouseButton (2))
			transform.RotateAround(
				new Vector3(-1.036919f,9.130455f,0.2638559f),
				new Vector3(0,1,0),
				4.8f*Input.GetAxis ("Mouse X"));

		if(Input.GetKey(KeyCode.E))transform.Rotate(0,0,-1);
		if(Input.GetKey(KeyCode.Q))transform.Rotate(0,0,1);

	}

	void OnGUI()
	{
		if(GUI.Button (new Rect (10, 10, 100, 30), "Reset")){
			transform.position=new Vector3(-5.639845f,1.978918f,-18.67214f);
			float radx=Mathf.Deg2Rad*(360f-347.1393f);
			transform.rotation=Quaternion.LookRotation(new Vector3(0,Mathf.Sin(radx),Mathf.Cos(radx)));
		}
		
		if(GUI.Button (new Rect (120, 10, 100, 30), "Help")){
			EN_help=!EN_help;
		}

		if (EN_help) {
			GUI.Label (new Rect (120, 50, 300, 260), 
@"[Controls]

Change view
===========
Fixed cam: (Key) 0
Viewing cam: (Key) 1

Navigate
==========
Rotate Camera: 
  (Mouse) HOLD Left btn
Move Camera: 
  Forward - (Key) Up W (Mouse) Wheel up
  Backward - (Key) Down S (Mouse) Wheel down
  Left - (Key) Left A
  Right - (Key) Rigth D
Roll Camera: 
  Clockwise - (Key) E
  Anticlockwise - (Key) Q
Rotate around the Pole: 
  (Mouse) HOLD Middle btn
"
			);
		}
	}
}
