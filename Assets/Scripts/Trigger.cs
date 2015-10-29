using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trigger : MonoBehaviour
{
	public List<GameObject> TriggerObjects;

	void Update()
	{
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = new Color(1, 1, 0, 0.3f);
		Gizmos.DrawCube(transform.position, transform.localScale);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(transform.position, transform.localScale);

		foreach (var triggerObj in TriggerObjects)
		{
			Gizmos.DrawLine(transform.position, triggerObj.transform.position);
		}
	}

	public void Activate()
	{
		foreach (var trigObj in TriggerObjects)
		{
			trigObj.SendMessage("Activate");
		}
	}
}
