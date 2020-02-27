using UnityEngine;


public class Hacker : MonoBehaviour
{
    //Game configuration data
    string [] level1Passwords = { "vlad", "alisa", "sharick", "sveta", "murthy" };
    string[] level2Passwords = { "police", "uniform", "arrest", "difficult", "murder" };
    //string[] level3Passwords = { "astronaut", "telescope", "enviroment", "milky_way", "spaceship" };

    //Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local Simple User");
        Terminal.WriteLine("Press 2 for the local Police Station");
        Terminal.WriteLine("Press 3 for the local NASA");
        Terminal.WriteLine("Enter your selection:");
    }
  
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "fuck" || input == "shit" || input == "fuck you") //easter egg
        {
            Terminal.WriteLine("Fucking swindler, choose the level!");
        }
        else
        {
            Terminal.WriteLine("Please, select a level!");
        }
    }
  
    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }

        Terminal.WriteLine("Please enter your password:");
    }
    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Try again, wrong password!");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("");
                break;
            case 2:
                Terminal.WriteLine("");
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
        Terminal.WriteLine("Well done!");
    }
    // Update is called once per frame

}