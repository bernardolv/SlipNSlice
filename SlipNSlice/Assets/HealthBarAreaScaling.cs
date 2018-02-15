using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarAreaScaling : MonoBehaviour {
	bool mygiven;
	RectTransform mytransform;
	float myheight;
	float mywidth;
	public float cardAreaDivider;
	public float mydivider;
	float theheight;
	// Use this for initialization
	void Start () {
		mygiven = false;
		mytransform = GetComponent<RectTransform> ();
	}

	// Update is called once per frame
	void Update () {
		if (CanvasBehaviour.given == true && mygiven == false) { //do this after the canvas behaviour coroutine giving size is done
			SetSize ();
			mygiven = true;
		}
		else if(CanvasBehaviour.height != theheight && myheight != null ){ //do this when the resolution changes (for tests mostly)
			SetSize();
		}
	}
	void SetSize(){
		myheight = CanvasBehaviour.height / mydivider ;
		mywidth = CanvasBehaviour.width;
		float offset = myheight / 2;
		float myy = (CanvasBehaviour.height / cardAreaDivider) + offset;
		mytransform.anchoredPosition = new Vector2 (0, myy);
		mytransform.sizeDelta = new Vector2 (mywidth, myheight);
		theheight = CanvasBehaviour.height;
	}
}
