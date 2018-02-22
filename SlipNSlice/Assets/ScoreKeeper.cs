using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {
	public static Dictionary<int, Block> blockdic = new Dictionary<int, Block>();
	// Use this for initialization
	void Start () {
		
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
	}

	public static void AddBlock(string newElement, int newNumber, int blockNumber){
		Block newblock = new Block (newElement, newNumber);

		blockdic.Add (blockNumber,newblock);


	}
}
