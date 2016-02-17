using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (GameManager.instance.state == "Game")
            {
                GameManager.instance.state = "Writing";
                StartCoroutine(Exit());
                GameManager.instance.CompletePuzzle();
                GameManager.instance.NextLevel();
            }
        }
    }

    IEnumerator Exit()
    {
        Vector3 startPos = transform.position;
        for (float i = 0; i < 1; i += .01f)
        {
            transform.position = Vector3.Lerp(startPos, new Vector3(-200, 37.8f, -766.1f), i);
            yield return null;
        }
        Destroy(gameObject);
    }
}
