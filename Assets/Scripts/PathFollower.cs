using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour
{
	public SplinePath Path;

	public float Frac = 0;

	public bool IsFollowing = false;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (IsFollowing)
		{
			var frac = (Mathf.Sin(Time.time * 2f) + 1f) / 2f;
			Frac = frac;
			transform.position = Path.GetPoint(frac);
		}
	}

	public void Activate()
	{
		IsFollowing = !IsFollowing;
	}
}
