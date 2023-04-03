using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementlimitation : MonoBehaviour
{
	
	public GameObject Capsule;

	private void OnTriggerEnter()
	{
		Capsule.SetActive(true);
	}

}
