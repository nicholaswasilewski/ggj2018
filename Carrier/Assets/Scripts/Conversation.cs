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
				con = new Conversation ("Turkey: What kind of jokes do you like?", "Ones that bowl me over.", "Dry humor.", "Slapstick", 1);
				break;
			case 2:
				con = new Conversation("Turkey: Are you into sports?", "Yes; if they involve fancy footwear.", "Yes; if they involve contact.", "No.", 1);
				break;
			case 3:
				con = new Conversation("Turkey: Three strikes…", "And you’re out.", "What did I say wrong?", "Is the best, especially at end.", 3);
				break;
			}
			break;
		case 2:
		// Eagle
			switch (convoNum) { 
			case 1:
				con = new Conversation ("Eagle: ROW! GAIN!", "GET! SWOLE!", "Nah, you don’t need that stuff.", "But I’m le tired.", 2);
				break;
			case 2:
				con = new Conversation ("Eagle: Leftovers for dinner?", "Not for me!", "The chicken that was left out overnight.", "Throw ‘em in the microwave!", 2);
				break;
			case 3:
				con = new Conversation ("Eagle: And an evening of…?", "Baseball.", "Song.", "Meditation.", 1);
				break;
			}
			break;
		case 3:
		// Wren
			switch (convoNum) {
			case 1:
				con = new Conversation ("Wren: YOU OWE ME WRENT.", "It’s not the first of the month!", "How much do I owe?", "Half now, half later.", 2);
				break;
			case 2:
				con = new Conversation ("Wren: IT’S GONE UP! IT’S GONE UP!", "That’s not in the contract!", "By how much?", "Wren does that take effect?", 2);
				break;
			case 3:
				con = new Conversation ("Wren: EVICTED!!!", "How about we go get a turkey leg?", "Have mercy!", "I’ll sue!", 1);
				break;
			}
			break;
		case 4:
		// Parrot
			switch (convoNum){
			case 1:
				con = new Conversation("Parrot: Do you have a favorite song?", "Puttin’ on the Ritz", "Free Bird", "Bolero", 3);
				break;
			case 2:
				con = new Conversation("Parrot: Squawk! Do you have a favorite song?", "Salty Dog", "Fly like an Eagle", "Pachelbel’s Cannon", 3);
				break;
			case 3:
				con = new Conversation("Parrot: Squawk! Do you have a favorite song?", "Low", "I’m like a Bird", "Rockaway Beach", 3);
				break;
			}
			break;
		case 5:
		// Ostrich
			switch (convoNum) {
			case 1:
				con = new Conversation ("Ostrich: LARGE AND IN CHARGE.", "Your head’s in the sand.", "I know someone who’s bigger.", "You’re quite impressive.", 3);
				break;
			case 2:
				con = new Conversation ("Ostrich: SPEEDY McFEETY.", "Drugs are bad.", "Some rollerblades would help.", "Faster than a speeding bullet.", 3);
				break;
			case 3:
				con = new Conversation ("Ostrich: … I just wish I could fly.", "Think of a wonderful thought!", "A jetpack will fix that.", "You’d make a great giraffe stunt double.", 1);
				break;
			}
			break;
		case 6:
		// EMU
			switch (convoNum) {
			case 1:
				con = new Conversation ("Emu: *Looks around nervously*", "Is everything okay?", "You’re looking a little oily today.", "What? Where??", 1);
				break;
			case 2:
				con = new Conversation ("Emu: *Starts shaking*", "Now you’re making ME nervous.", "Here’s a nice facial cleanser.", "How about a hug?", 3);
				break;
			case 3:
				con = new Conversation ("Emu: *Eyes bulge*", "SAFETY IN NUMBERS.", "I’ll use the oil for tonight’s dinner!", "I’ll prepare a nice hot bath.", 3);
				break;
			}
			break;
		}
		return con;
	}
}
