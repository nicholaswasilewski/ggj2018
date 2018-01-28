using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	public static Conversation makeConversationWithBird(int currentBird){
		Conversation con = null;

		// gets current bird number
		int birdNum = currentBird;
		// take that bird number and load the appropriate conversation based on it
		switch (birdNum)
		{
		case 1:
		  // Turkey
			con = new Conversation("THREE’S A CROWD.", "GUTTER BALL", "TURKEY” (joins the party)", "ON STRIKE", 2);
			break;
		case 2:
		// Eagle
			con = new Conversation("ROW! GAIN!", "BALDNESS IS HEREDITARY", "BALD IS BEAUTIFUL", "STARING ISN’T POLITE", 2);
			break;
		case 3:
		// Wren
			con = new Conversation("YOU OWE ME.", "PAY UP", "EVICTED!", "IT’S THE FIRST.", 1);
			break;
		case 4:
		// Parrot
			con = new Conversation("ARE YOU THIRSTY?", "SUPER DUPER!", "PUT ON THE RITZ.", "EAT ANOTHER CRACKER.", 1);
			break;
		case 5:
		// Ostrich
			con = new Conversation("bird 5", "response 5-1", "response 5-2", "response 5-3", 3);
			break;
		case 6:
		// EMU
			con = new Conversation("IS MY SKIN OILY?", "I’M SO NERVOUS.", "WAITWHATWHY.", "RIGHT; NO NEED TO WORRY.", 3);
			break;

		}
		return con;
	}
}
