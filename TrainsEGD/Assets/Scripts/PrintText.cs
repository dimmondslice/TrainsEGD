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
                GameManager.instance.state = "Text";
                textField.text = GameManager.instance.GetCurrentDialogue();
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
            textBack.sizeDelta = new Vector2(textField.preferredWidth + 50, 150);
            yield return new WaitForSeconds(.05f);
        }
        GameManager.instance.writingText = false;
        GameManager.instance.state = "Text";
    }
}
