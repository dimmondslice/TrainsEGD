using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrintText : MonoBehaviour {

    Text textField;
    RectTransform textBack;

	// Use this for initialization
	void Start () {
        textField = GetComponent<Text>();
        textBack = GameObject.Find("Image").GetComponent<RectTransform>();
        GameManager.instance.MyAwake();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (GameManager.instance.state == "Text")
            {
                GameManager.instance.NextLevel();
            }
            else if (GameManager.instance.state == "Writing")
            {
                StopAllCoroutines();
                textField.text = GameManager.instance.GetCurrentDialogue();
                textBack.sizeDelta = new Vector2(textField.preferredWidth + 50, textField.preferredHeight);
                if (GameManager.instance.currentLevel < GameManager.instance.puzzleObjects.Length)
                {
                    GameManager.instance.state = "Text";

                }
                else if (GameManager.instance.currentLevel < GameManager.instance.dialogue.Length)
                {
                    GameManager.instance.currentLevel++;
                    GameManager.instance.state = "End";
                }
            }
            else if (GameManager.instance.state == "End")
            {
                GameManager.instance.state = "Writing";
                if (GameManager.instance.currentLevel < GameManager.instance.dialogue.Length)
                    StartWriteText(GameManager.instance.dialogue[GameManager.instance.currentLevel]);
            }

        }
    }

    public void StartWriteText(string text)
    {
        GameManager.instance.writingText = true;
        StartCoroutine(WriteText(text));
    }

    IEnumerator WriteText(string text)
    {
        textField.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            textField.text += text[i];
            textBack.sizeDelta = new Vector2(textField.preferredWidth + 50, textField.preferredHeight);
            yield return new WaitForSeconds(.05f);
        }

        if (GameManager.instance.currentLevel < GameManager.instance.puzzleObjects.Length)
        {
            GameManager.instance.writingText = false;
            GameManager.instance.state = "Text";
        }
        else if(GameManager.instance.currentLevel < GameManager.instance.dialogue.Length)
        {
            GameManager.instance.currentLevel++;
            GameManager.instance.state = "End";
        }
    }
}
