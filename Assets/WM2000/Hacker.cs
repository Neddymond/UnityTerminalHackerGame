using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    //Game configuration data
    string menuHint = "You may type menu at anytime";
	string[] level1Passwords = {"come", "home", "child", "cloth", "watch", "table"};
	string[] level2Passwords = {"mundane","clout","medium","walking","hopeful","binary"};
	string[] level3Passwords = {"excruciate", "exasperate", "audacity", "mutinous", "feminism", "egalitarian"};
	//Game state
	int level;
	string Password;


	enum Screen {MainMenu, Password, Win};
	Screen currentScreen;

	// Use this for initialization
	void Start 	() 
	{
		ShowMainMenu ();
	}
		

	void ShowMainMenu () 
	{
		currentScreen = Screen.MainMenu;
		Terminal.ClearScreen ();
		Terminal.WriteLine ("What would you like to hack into?");
		Terminal.WriteLine ("Press 1 for Mouwa's Library");
		Terminal.WriteLine ("Press 2 for Wole Soyinka's Library?");
		Terminal.WriteLine ("Press 3 for Chinedu's Library?");
		Terminal.WriteLine ("Enter your Selection:");
 }

	void OnUserInput (string input)
	{
		if (input == "menu") 
		{
			ShowMainMenu ();
		} 
		else if (currentScreen == Screen.MainMenu) 
		{
			RunMainMenu (input);
		} 
		else if (currentScreen == Screen.Password) 
		{
			checkPassword (input);
		}
	}

	void RunMainMenu (string input)
	{
		bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
		if (isValidLevelNumber) 
		{
			level = int.Parse (input);
            AskForPassword();
		}
        else if (input == "close" || input == "quit" || input == "exit")
        {
            Terminal.WriteLine("if on the web, close the tab");
            Application.Quit();
        }
		else if (input == "666") 
		{
			Terminal.WriteLine ("please select a level dude");
		}
		else 
		{
			Terminal.WriteLine ("invalid Password");
            Terminal.WriteLine(menuHint);
		}
	}
		

	void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your Password, hint: " + Password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                Password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                Password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                Password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void checkPassword(string input)
	{
		if ( input == Password) 
		{
			DisplayWinScreen ();
		} 

		else 
		{
            AskForPassword();
		}
	}

    void DisplayWinScreen ()
	{
		currentScreen = Screen.Win;
		Terminal.ClearScreen();
		ShowLevelReward ();
        Terminal.WriteLine(menuHint);
    }

	void ShowLevelReward ()
	{
		switch(level) 
		{
		case 1:
			Terminal.WriteLine ("Have a book...");
			Terminal.WriteLine (@"

    _________
   /        //
  /        //
 /________//
(________(/
"
 			);
			break;
		case 2:
			Terminal.WriteLine ("You got the key!");
            Terminal.WriteLine("play again for greater challenge");
            Terminal.WriteLine (@"
 
  __
 /0 \______
 \__/-=' ='     
"
 			);
            

            break;
		case 3:
			Terminal.WriteLine ("You unlocked the door to the greatest challenge!");
			Terminal.WriteLine (@"
   __________  
  |          |
  |          |
  | o        |
  |          |
  |          |
  |__________|
"
 			);
                break;
		default:
			Debug.LogError ("Invalid level reached");
			break;
		}
	}
}
	