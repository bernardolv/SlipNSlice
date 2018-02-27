using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroScore : MonoBehaviour {
	string myscoremultiplier;
	public GameObject mytextholder;
	string myelement;
	float scoremultiplier;
	// Use this for initialization
	void Start () {
		myelement = transform.tag;
		scoremultiplier = 0;
		myscoremultiplier = "0";
		mytextholder.GetComponent<Text> ().text = myscoremultiplier;
	}
	
	// Update is called once per frame
	void Update () {
		if (scoremultiplier != ScoreKeeper.baseElementMultipliers[myelement]) {
			scoremultiplier = ScoreKeeper.baseElementMultipliers[myelement];
			mytextholder.GetComponent<Text> ().text = scoremultiplier.ToString ();
		}
	}
}
