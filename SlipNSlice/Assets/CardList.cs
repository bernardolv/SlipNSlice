using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour {
	public static Dictionary<int, Card> carddic = new Dictionary<int, Card>();
	private static CardList instance = null;


/*		ID = newID;
		Name = newName;
		Element = newElement;
		ActiveSkill = newActiveSkill;
		PassiveSkill = newPassiveSkill;
		Attack = newAttack;
		Defense = newDefense;
*/
	// Use this for initialization
	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
			return;
		}
		Destroy (this.gameObject);
	}

	void Start () {
		Card no1 = new Card(1, "WaterStarter", "Water", "Active1","Passive1", 10, 10, 1, 1);
		Card no2 = new Card(2, "WaterContinuer", "Water", "Active1.1","Passive1.1", 20, 20, 1, 1); 
		Card no3 = new Card(3, "WaterFinisher", "Water", "Active1.2","Passive1.2", 30, 30, 1, 1); 
		Card no4 = new Card(4, "FireStarter", "Fire", "Active2","Passive2", 10, 10, 1 ,1); 
		Card no5 = new Card(5, "FireContinuer", "Fire", "Active2.1","Passive2.1", 20, 20,1 ,1); 
		Card no6 = new Card(6, "FireEnder", "Fire", "Active2.2","Passive2.2", 30, 30,1,1); 
		Card no7 = new Card(7, "GrassStarter", "Grass", "Active3","Passive3", 10, 10,1,1); 
		Card no8 = new Card(8, "GrassContinuer", "Grass", "Active3.1","Passive3.1", 20, 20,1,1); 
		Card no9 = new Card(9, "GrassEnder", "Grass", "Active3.2","Passive3.2", 30, 30,1,1); 
		Card no10 = new Card(10, "DarkStarter", "Dark", "Active4","Passive4", 10, 10,1,1); 
		Card no11 = new Card(11, "DarkContinuer", "Dark", "Active4.1","Passive4.1", 20, 20,1,1); 
		Card no12 = new Card(12, "DarkEnder", "Dark", "Active4.2","Passive4.2", 30, 30,1,1); 



		carddic.Add(1, no1);
		carddic.Add(2, no2);
		carddic.Add(3, no3);
		carddic.Add(4, no4);
		carddic.Add(5, no5);
		carddic.Add(6, no6);
		carddic.Add(7, no7);
		carddic.Add(8, no8);
		carddic.Add(9, no9);
		carddic.Add(10, no10);
		carddic.Add(11, no11);
		carddic.Add(12, no12);


//		Debug.Log (carddic.Count);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
