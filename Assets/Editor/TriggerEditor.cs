using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Trigger))]
public class TriggerEditor : Editor
{
	public Trigger TriggerObject
	{
		get
		{
			return (Trigger)target;
		}
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		//EditorGUILayout.
		if (Application.isPlaying)
		{
			if (GUILayout.Button("Activate Trigger"))
			{
				ActivateTrigger();
			}
		}
	}

	public void ActivateTrigger()
	{
		Debug.Log("Trigger Activated!");
		TriggerObject.Activate();
	}
}
