using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ShowMainMenu ();
	}

	Terminal.WriteLine
	void ShowMainMenu () {
		Terminal.ClearScreen ();
		var greeting = "Hello Ben";
		Terminal.WriteLine (greeting);
		Terminal.WriteLine ("What would you like to hack into?");
		Terminal.WriteLine ("Press 1 for Mouwa's Library");
		Terminal.WriteLine ("Press 2 for Wole Soyinka's Library?");
		Terminal.WriteLine ("Press 3 for Chinedu's Library?");
		Terminal.WriteLine ("Enter your Selection:");
 }

	void OnUserInput (string Input) {
	print(Input);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
