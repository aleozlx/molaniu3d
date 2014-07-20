using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Director : MonoBehaviour {
	public Camera Viewing;
	public Camera Fixed;
	List<Camera> allCams;

	void Start () {
		allCams = new List<Camera> (new Camera[]{Fixed,Viewing});
		ActiveCamera (Viewing);
	}

	void Update () {
		if(Input.GetKeyUp(KeyCode.Alpha0))ActiveCamera(Fixed);
		else if(Input.GetKeyUp(KeyCode.Alpha1))ActiveCamera(Viewing);
	}

	void ActiveCamera(Camera c){
		foreach (Camera i in allCams) i.gameObject.SetActive(false);
		c.gameObject.SetActive(true);
	}

	void OnGUI()
	{
		if(Fixed.gameObject.activeSelf){
			if(GUI.Button (new Rect (10, 10, 100, 30), "Back"))
				ActiveCamera(Viewing);
		}
	}
}
