using UnityEngine;
using System.Collections;

public class Jostle : MonoBehaviour
{
	public float MaxJostleForce;
	public float minWaitTime;
	public float maxWaitTime;

	[HideInInspector]
	public bool jostling;

    private Rigidbody rb;

    void Start()
     {
         rb = GetComponent<Rigidbody>();
		 jostling = true;

         StartCoroutine(JostleTrain());
     }

     IEnumerator JostleTrain()
     {
		while (jostling)
		{
			float jostleForce = Random.Range(-MaxJostleForce, MaxJostleForce);
			float randSeconds = Random.Range(minWaitTime, maxWaitTime);
			rb.AddForceAtPosition( transform.forward * jostleForce, Vector3.up * .5f);

			yield return new WaitForSeconds(randSeconds);
		}
     }
}
