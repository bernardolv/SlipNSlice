using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkillBar : MonoBehaviour {
	public GameObject myhero;
	float mypercent;
	public float myactivemax;
	float mycurrentint;
	public int mynum;

	// Use this for initialization
	void Start () {
		int myvalue = 0;
		this.transform.localScale = new Vector3 (0f, .1f, 1f);
		mycurrentint = 0;
		mypercent = 0;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateBar (mynum);
	}

	void UpdateBar(int num){
		if (mycurrentint != ScoreKeeper.activeSkillMultipliers [num]) {
			mycurrentint = ScoreKeeper.activeSkillMultipliers [num];
			Debug.Log ("num is " + mycurrentint);
			Debug.Log ("active max" + myactivemax);
			float mynewscale = mycurrentint / myactivemax;
			Debug.Log ("myscale is " + mynewscale);
			this.transform.localScale = new Vector3 (mynewscale, .1f, 1f);
		}
	}
}
