using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {


    int rotationError;
    public Vector3 correctAngle;
    Quaternion qAngle;

    public float xOffset = 169.2f;
    public float yOffset = 9.3f;

	// Use this for initialization
	void Start ()
    {
        rotationError = 5;
        qAngle = Quaternion.Euler(correctAngle);
        //correctAngle = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
    void Update()
    {
        qAngle = Quaternion.Euler(correctAngle.x, correctAngle.y, transform.eulerAngles.z);

        //Vector3 eulerAngles = transform.eulerAngles;

        //print(Quaternion.Angle(transform.rotation, qAngle));

        if((Quaternion.Angle(transform.rotation, qAngle) < rotationError) && Input.GetAxis("Mouse Y") == 0 && Input.GetAxis("Mouse X") == 0)
        {
            GameManager.instance.state = "Solved";
            StartCoroutine(ShowCorrect());
            //GameManager.instance.CompletePuzzle();
            //print("Good");
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && GameManager.instance.state == "Solved")
        {
            GameManager.instance.state = "Writing";
            StartCoroutine(CloudExit());
            GameManager.instance.CompletePuzzle();
        }

    }
	void FixedUpdate () {
        if (GameManager.instance.state == "Game")
        {
            float x = ((Input.mousePosition.x / Screen.width) -.5f) * 180;
            float y = ((Input.mousePosition.y / Screen.height) - .5f) * 180;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(y + yOffset, x + xOffset, 0)), .1f);
            //transform.rotation = Quaternion.Euler(new Vector3(y + yOffset, x + xOffset, 0));
            /*if (Input.GetKey(KeyCode.Mouse0))
            {
                Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse Y"), -1 * Input.GetAxis("Mouse X"), 0);
                transform.Rotate(mouseMovement * 5, Space.World);
                //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            }*/
        }
	}

    IEnumerator ShowCorrect()
    {
        Quaternion endTransform = transform.rotation;
        for (float i = 0; i < 1; i += .04f)
        {
            transform.rotation = Quaternion.Slerp(endTransform, qAngle, i);
            yield return null;
        }
    }

    IEnumerator CloudExit()
    {
        Vector3 startPos = transform.position;
        for (float i = 0; i < 1; i += .01f)
        {
            transform.position = Vector3.Lerp(startPos, new Vector3(-1000, 208, 66), i);
            yield return null;
        }
        Destroy(gameObject);
    }

    public void StartCloudEnter()
    {
        StartCoroutine(CloudEnter());
    }

    IEnumerator CloudEnter()
    {
        Vector3 startPos = transform.position;
        for (float i = 0; i < 1; i += .01f)
        {
            transform.position = Vector3.Lerp(startPos, new Vector3(-161, 208, 66), i);
            yield return null;
        }
    }
}
