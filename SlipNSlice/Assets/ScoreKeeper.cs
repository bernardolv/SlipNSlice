using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {
	public static Dictionary<int, Block> blockdic = new Dictionary<int, Block>();
	public static Dictionary <int, string> elementblocks = new Dictionary<int,string>();
	public static Dictionary <int, int> numberblocks = new Dictionary<int,int>();
	public static Dictionary <int, string> uniqueelements = new Dictionary<int,string>();
	public static int straightkeeper;
	public static bool isstraighthappening;
	public static Dictionary <string, float> baseElementMultipliers = new Dictionary<string,float> ();
	public static Dictionary <int, float> activeSkillMultipliers = new Dictionary<int,float> ();

	public static string[] elementstorer;
	public static int sameElementCounter;
	public static int sameNumberCounter;
	// Use this for initialization
	void Start () {
		sameElementCounter = 0;
		straightkeeper = 0;
		sameNumberCounter = 0;
		activeSkillMultipliers [1] = 0;
		activeSkillMultipliers [2] = 0;
		activeSkillMultipliers [3] = 0;
		activeSkillMultipliers [4] = 0;
		baseElementMultipliers ["Fire"] = 0;
		baseElementMultipliers ["Water"] = 0;
		baseElementMultipliers ["Grass"] = 0;
		baseElementMultipliers ["Dark"] = 0;


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.T)){
			for (int i =1; i < blockdic.Count + 1;i++){
				Block myblock = blockdic[i];
				Debug.Log(myblock.element + myblock.number);
			}
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			blockdic.Clear ();
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			GetScoreInts ();
			elementblocks.Clear ();

		}
	}

	public static void AddBlock(string newElement, int newNumber, int blockNumber){
		Block newblock = new Block (newElement, newNumber);

		blockdic.Add (blockNumber,newblock);


	}

	public static void GetScoreInts(){
		for (int i = 1; i < blockdic.Count + 1; i++) {
			CheckSameElement (i);
			//CheckSameNumber ();
		}
		elementblocks.Clear ();
		blockdic.Clear ();
	}
	public static void CheckSameElement(int num){
		string myelement = blockdic [num].element;
		if (num == 1){
			elementblocks.Add (num, myelement);
			Debug.Log("First block");
		}
		else if (elementblocks.ContainsValue (myelement)) {
			sameElementCounter++;
			elementblocks.Add (num, myelement);
			assignElementScore (myelement, sameElementCounter);
			//Debug.Log ("Same Color" + (sameElementCounter + 1));
		} else {
			Debug.Log ("New Element");
			if (sameElementCounter == 0) {
				//Debug.Log ("No Element Combos");
			} else {
				//Debug.Log (sameElementCounter + 1 + " of same before broken");
			}
			sameElementCounter = 0;
			elementblocks.Clear ();
			elementblocks.Add (num, myelement);
		}
	}
	public static void CheckSameNumber(int num){
		int mynumber = blockdic [num].number;
		if (num == 1){
			numberblocks.Add (num, mynumber);
		}
		else if (numberblocks.ContainsValue (mynumber)) {
			sameNumberCounter++;
			numberblocks.Add (num, mynumber);
			assignNumberScore(mynumber, sameNumberCounter);
			//Debug.Log ("Same Number" + (sameNumberCounter + 1));
		} else {
			Debug.Log ("New Number");
			if (sameNumberCounter == 0) {
				//Debug.Log ("No Number Combos");
			} else {
				//Debug.Log (sameNumberCounter + 1 + " of same before broken");
			}
			sameNumberCounter = 0;
			numberblocks.Clear ();
			numberblocks.Add (num, mynumber);
		}
	}
	public static void CheckStraight(int num){
		int mynumber = blockdic [num].number;
		if (mynumber == 1) {
			straightkeeper = 1;
		} else if (mynumber == 2 && straightkeeper == 1) {
			straightkeeper = 2;
		} else if (mynumber == 3 && straightkeeper == 2) {
			straightkeeper = 3;
		} else if (mynumber == 4 && straightkeeper == 3) {
			straightkeeper = 4;
			assignStraightScore (1, 1);
			assignStraightScore (2, 1);
			assignStraightScore (3, 1);
			assignStraightScore (4, 1);
			Debug.Log ("Straight finished");
		} else {
			straightkeeper = 0;
		}
	}
	public static void CheckUniqueElement(int num){
		string myelement = blockdic [num].element;
		if (uniqueelements.ContainsValue(myelement)) {
			Debug.Log("Unique broken");
			uniqueelements.Clear();
		} else {
			int counter = uniqueelements.Count;
			counter = counter + 1;
			Debug.Log("tile numer" + counter);
			uniqueelements.Add (counter, myelement);
			if (uniqueelements.Count == 4) {
				Debug.Log ("RAINBOW");
				uniqueelements.Clear ();
				assignUniqueElementScore ("Grass", 1);
				assignUniqueElementScore ("Water", 1);
				assignUniqueElementScore ("Fire", 1);
				assignUniqueElementScore ("Dark", 1);	

			}

		} 
	}
	public static void assignStraightScore(int number, int multiplier){
		float currentscore = activeSkillMultipliers [number];
		currentscore = currentscore + multiplier;
		activeSkillMultipliers [number] = currentscore;
	}
	public static void assignNumberScore (int activenum, int combocounter){
		Debug.Log (combocounter);
		float currentscore = activeSkillMultipliers [activenum];
		float multiplier = 0;
		if (combocounter == 1) {
			multiplier = 1f;
		}
		if (combocounter == 2) {
			multiplier = .5f;
		}
		if (combocounter == 3) {
			multiplier = 1.5f;
		}
		if (combocounter > 3) {
			multiplier = .5f;
		}
		currentscore = currentscore + multiplier;
		activeSkillMultipliers [activenum] = currentscore;
		//Debug.Log (element + "+" + currentscore);
	}
	public static void assignElementScore(string element, int combocounter){
		Debug.Log (combocounter);
		float currentscore = baseElementMultipliers [element];
		float multiplier = 0;
		if (combocounter == 1) {
			multiplier = 1f;
		}
		if (combocounter == 2) {
			multiplier = .5f;
		}
		if (combocounter == 3) {
			multiplier = 1.5f;
		}
		if (combocounter > 3) {
			multiplier = .5f;
		}
		currentscore = currentscore + multiplier;
		baseElementMultipliers [element] = currentscore;
		Debug.Log (element + "+" + currentscore);
	}
	public static void assignUniqueElementScore(string element, int multiplier){
				float currentscore = baseElementMultipliers [element];
				currentscore = currentscore + multiplier;
				baseElementMultipliers [element] = currentscore;
	}
}
