using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card {
	public int ID;
	public string Name;
	public string Element;
	public string ActiveSkill;
	public string PassiveSkill;
	public int Attack;
	public int Defense;
	public int Level;
	public int experience;
	public int levelexperience;

	public Card (int newID, string newName, string newElement, string newActiveSkill, string newPassiveSkill, int newAttack, int newDefense){
		ID = newID;
		Name = newName;
		Element = newElement;
		ActiveSkill = newActiveSkill;
		PassiveSkill = newPassiveSkill;
		Attack = newAttack;
		Defense = newDefense;

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
