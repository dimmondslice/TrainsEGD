using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : ScriptableObject {


    public string[] dialogue;
    public GameObject[] puzzleObjects;
    public int currentLevel = 0;
    public string state = "Writing";
    public bool writingText = false;
    public bool canRotate = false;

    GameObject textField;
    GameObject textArea;
    GameObject currentObject;
    PrintText pText;

    static private bool instantiated = false;
    static private GameManager _instance;
    static public GameManager instance
    {
        get
        {
            if (instantiated)
                return _instance;
            else
            {

                instantiated = true;
                _instance = CreateInstance<GameManager>();
                //_instance.MyAwake();
                return _instance;
            }
        }
        private set { _instance = value; }
    }

    public void MyAwake()
    {
        dialogue = new string[] { "Why can't life be fun all the time?",
                                  "I wonder where this train's going?\n Hopefully somewhere more fun than home...",
                                  "Mom and Dad make me so angry sometimes...",
                                  "Will I ever go back? Will I miss home?",
                                  "I want to go home . . . but I can't",
                                  "Home is gone.",
                                  "It was destroyed in the fighting . . . \nJust like everything else"};
        puzzleObjects = new GameObject[] {Resources.Load<GameObject>("cloud_teddybear"),
                                          Resources.Load<GameObject>("cloud_knapsack"),
                                          Resources.Load<GameObject>("cloud_house"),
                                          Resources.Load<GameObject>("cloud_train"),
                                          Resources.Load<GameObject>("cloud_mushroomcloud")};

        textField = GameObject.Find("Text");
        textArea = GameObject.Find("TextArea");
        pText = textField.GetComponent<PrintText>();

        pText.StartWriteText(dialogue[currentLevel]);
        if (currentLevel < puzzleObjects.Length)
        {
            currentObject = Instantiate<GameObject>(puzzleObjects[currentLevel]);
            currentObject.transform.position = new Vector3(550, 198, 66);
            canRotate = false;
            currentObject.GetComponent<Spin>().StartCloudEnter();
        }
        
        //textField.GetComponent<Text>().text = dialogue[currentLevel];
    }

    public void NextLevel()
    {
        //if (state == "Text") 
        state = "Game";
        currentLevel++;
        /*if (currentLevel < puzzleObjects.Length)
        {
            
            currentObject = Instantiate<GameObject>(puzzleObjects[currentLevel]);
            //Debug.Break();
        }*/
        textArea.SetActive(false);
    }

    public void CompletePuzzle()
    {
        state = "Writing";
        //Destroy(currentObject);
        textArea.SetActive(true);
        if (currentLevel < dialogue.Length)
        {
            pText.StartWriteText(dialogue[currentLevel]);
            //textField.GetComponent<Text>().text = dialogue[currentLevel];
        }
        if (currentLevel < puzzleObjects.Length)
        {
            currentObject = Instantiate<GameObject>(puzzleObjects[currentLevel]);
            currentObject.transform.position = new Vector3(550, 198, 66);
            currentObject.GetComponent<Spin>().StartCloudEnter();
        }
    }

    public string GetCurrentDialogue()
    {
        return dialogue[currentLevel];
    }
}
