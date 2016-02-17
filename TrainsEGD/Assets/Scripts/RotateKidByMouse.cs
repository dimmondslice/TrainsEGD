using UnityEngine;
using System.Collections;

public class RotateKidByMouse : MonoBehaviour
{
	public float maxYRot;
	public float maxXRot;

	void Update ()
	{
		//get mouse location from center of screen as percentage of the way to the edge
		float x = ((Input.mousePosition.x / Screen.width) - .5f) * maxYRot;
		float y = ((Input.mousePosition.y / Screen.height) - .5f) * maxXRot;

		//rotate the character  via lerp to the max allowed rotation times the mouse input to screen ratio. subtract 80 for magic good looking angle
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0 , x - 80, y)), .1f);
	}
}
