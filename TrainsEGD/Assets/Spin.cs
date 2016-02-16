using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {


    int rotationError;
    public Vector3 correctAngle;
    Quaternion qAngle;

	// Use this for initialization
	void Start ()
    {
        rotationError = 20;
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
            GameManager.instance.CompletePuzzle();
            //print("Good");
        }
         
    }
	void FixedUpdate () {
        if (GameManager.instance.state == "Game")
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse Y"), -1 * Input.GetAxis("Mouse X"), 0);
                transform.Rotate(mouseMovement * 5, Space.World);
                //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            }
        }
	}
}
