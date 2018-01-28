using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterConversation {
	public int BirdNum;
	public int CurrentConversation;
	public Conversation Conversation1;
	public Conversation Conversation2;
	public Conversation Conversation3;
	public int Score;

	public MasterConversation(int currentBird, int currentConversation){
		this.BirdNum = currentBird;
		this.CurrentConversation = currentConversation;
		this.Conversation1 = Conversation.makeConversationWithBird(currentBird, 1);
		this.Conversation2 = Conversation.makeConversationWithBird(currentBird, 2);
		this.Conversation3 = Conversation.makeConversationWithBird(currentBird, 3);
		this.Score = 0;
	}
}

public class Conversation {
	public string Question;
	public string Answer1;
	public string Answer2;
	public string Answer3;
	public int CorrectAnswer;

	public Conversation(string q, string a1, string a2, string a3, int a4) {
		this.Question = q;
		this.Answer1 = a1;
		this.Answer2 = a2;
		this.Answer3 = a3;
		this.CorrectAnswer = a4;
	}
	public static Conversation makeConversationWithBird(int currentBird, int convoNum){
		Conversation con = null;

		// gets current bird number
		int birdNum = currentBird;
		// take that bird number and load the appropriate conversation based on it
		Debug.Log ("Bird num: " + birdNum);
		switch (birdNum)
		{
		case 1:
		  // Turkey
			switch (convoNum) 
			{ 
			case 1:
				con = new Conversation ("THREE’S A CROWD.", "GUTTER BALL", "TURKEY” (joins the party)", "ON STRIKE", 1);
				break;
			case 2:
				con = new Conversation("Turkey 2.", "GUTTER BALL", "TURKEY” (joins the party)", "ON STRIKE", 2);
				break;
			case 3:
				con = new Conversation("Turkey 3.", "GUTTER BALL", "TURKEY” (joins the party)", "ON STRIKE", 3);
				break;
			}
			break;
		case 2:
		// Eagle
			switch (convoNum) { 
			case 1:
				con = new Conversation ("ROW! GAIN!", "BALDNESS IS HEREDITARY", "BALD IS BEAUTIFUL", "STARING ISN’T POLITE", 2);
				break;
			case 2:
				con = new Conversation ("ROW! GAIN!", "BALDNESS IS HEREDITARY", "BALD IS BEAUTIFUL", "STARING ISN’T POLITE", 2);
				break;
			case 3:
				con = new Conversation ("ROW! GAIN!", "BALDNESS IS HEREDITARY", "BALD IS BEAUTIFUL", "STARING ISN’T POLITE", 2);
				break;
			}
			break;
		case 3:
		// Wren
			switch (convoNum) {
			case 1:
				con = new Conversation ("YOU OWE ME.", "PAY UP", "EVICTED!", "IT’S THE FIRST.", 1);
				break;
			case 2:
				con = new Conversation ("YOU OWE ME.", "PAY UP", "EVICTED!", "IT’S THE FIRST.", 1);
				break;
			case 3:
				con = new Conversation ("YOU OWE ME.", "PAY UP", "EVICTED!", "IT’S THE FIRST.", 1);
				break;
			}
			break;
		case 4:
		// Parrot
			switch (convoNum){
			case 1:
				con = new Conversation("ARE YOU THIRSTY?", "SUPER DUPER!", "PUT ON THE RITZ.", "EAT ANOTHER CRACKER.", 1);
				break;
			case 2:
				con = new Conversation("ARE YOU THIRSTY?", "SUPER DUPER!", "PUT ON THE RITZ.", "EAT ANOTHER CRACKER.", 1);
				break;
			case 3:
				con = new Conversation("ARE YOU THIRSTY?", "SUPER DUPER!", "PUT ON THE RITZ.", "EAT ANOTHER CRACKER.", 1);
				break;
			}
			break;
		case 5:
		// Ostrich
			switch (convoNum) {
			case 1:
				con = new Conversation ("LARGE AND IN CHARGE.", "YOUR HEAD’S IN THE SAND.", "WHO’S LARGER!?", "“SHOW ME A BIGGER BIRD.", 3);
				break;
			case 2:
				con = new Conversation ("LARGE AND IN CHARGE.", "YOUR HEAD’S IN THE SAND.", "WHO’S LARGER!?", "“SHOW ME A BIGGER BIRD.", 3);
				break;
			case 3:
				con = new Conversation ("LARGE AND IN CHARGE.", "YOUR HEAD’S IN THE SAND.", "WHO’S LARGER!?", "“SHOW ME A BIGGER BIRD.", 3);
				break;
			}
			break;
		case 6:
		// EMU
			switch (convoNum) {
			case 1:
				con = new Conversation ("IS MY SKIN OILY?", "I’M SO NERVOUS.", "WAITWHATWHY.", "RIGHT; NO NEED TO WORRY.", 3);
				break;
			case 2:
				con = new Conversation ("IS MY SKIN OILY?", "I’M SO NERVOUS.", "WAITWHATWHY.", "RIGHT; NO NEED TO WORRY.", 3);
				break;
			case 3:
				con = new Conversation ("IS MY SKIN OILY?", "I’M SO NERVOUS.", "WAITWHATWHY.", "RIGHT; NO NEED TO WORRY.", 3);
				break;
			}
			break;
		}
		return con;
	}
}
