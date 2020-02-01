using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreenTest : MonoBehaviour {

	// Disable the behaviour when it becomes invisible...
	void OnBecameInvisible()
	{
		Debug.Log("YA NO ESTOY VISIBLE!");
	}

	// ...and enable it again when it becomes visible.
	void OnBecameVisible()
	{
		Debug.Log("HEY, ESTOY VISIBLE!");
	}
}
