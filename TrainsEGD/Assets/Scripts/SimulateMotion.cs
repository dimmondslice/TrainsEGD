using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SimulateMotion : MonoBehaviour
{
	public Vector3 moveSpeed;

	private List<GameObject> movingObjects;

	void Start ()
	{
		movingObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Parallax"));
	}
	
	void Update ()
	{
		foreach(GameObject g in movingObjects)
		{
			g.transform.Translate(moveSpeed * Time.deltaTime);
		}
	}
}
