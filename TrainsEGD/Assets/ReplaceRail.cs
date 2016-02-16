using UnityEngine;
using System.Collections;

public class ReplaceRail : MonoBehaviour
{
	void Update ()
	{
		if(transform.localPosition.x <= -90)
		{
			transform.localPosition = new Vector3(30,transform.localPosition.y,transform.localPosition.z);
		}
	}
}
