using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation {
	public string Question;
	public string Answer1;
	public string Answer2;
	public string Answer3;

	public Conversation(string q, string a1, string a2, string a3) {
		this.Question = q;
		this.Answer1 = a1;
		this.Answer2 = a2;
		this.Answer3 = a3;
	}
	public static Conversation makeConversationWithBird(int currentBird){
		Conversation con = null;

		// gets current bird number
		int birdNum = currentBird;
		// take that bird number and load the appropriate conversation based on it 
		switch (birdNum)
		{
		case 1:
			con = new Conversation("bird 1", "response 1-1", "response 1-1", "response 1-3");
			break;
		case 2:
			con = new Conversation("bird 2", "response 2-1", "response 2-2", "response 2-3");
			break;
		case 3:
			con = new Conversation("bird 3", "response 3-1", "response 3-2", "response 3-3");
			break;
		case 4:
			con = new Conversation("bird 4", "response 4-1", "response 4-2", "response 4-3");
			break;
		case 5:
			con = new Conversation("bird 5", "response 5-1", "response 5-2", "response 5-3");
			break;
		case 6:
			con = new Conversation("bird 6", "response 6-1", "response 6-2", "response 6-3");
			break;

		}
		return con;
	}
}

