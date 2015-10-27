using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SplinePath : MonoBehaviour
{
	[RangeAttribute(0, 1)]
	public float TrackingPosition = 0f;

	public List<Vector3> ControlPoints
	{
		get
		{
			return GetComponentsInChildren<Transform>().Where(t => t != transform).Select(t => t.position).ToList();
		}
	}

	private void OnDrawGizmos()
	{
		var cp = ControlPoints;

		Gizmos.color = Color.green;

		if (cp.Count > 1)
		{
			var prev = cp.First();
			foreach (var p in cp.Skip(1))
			{
				//Gizmos.DrawLine(prev, p);
				//Gizmos.DrawSphere(p, 0.5f);
				Gizmos.DrawWireSphere(p, 0.5f);
				prev = p;

				// draw smooth lines

				var points = ControlPoints.Take(4).ToArray();

				var prevL = GetPoint(0f, points);
				for (var i = 0.1f; i <= 1f; i += 0.1f)
				{
					var s = GetPoint(i, points); // GetPoint(i);
												 //Gizmos.DrawWireSphere(s, 0.1f);
					Gizmos.DrawLine(prevL, s);
					prevL = s;
				}
				Gizmos.DrawLine(prevL, GetPoint(1f, points));
			}
		}

		Gizmos.color = Color.yellow;
		//Gizmos.DrawSphere(GetPoint(points), 0.4f);
	}

	private Vector3 GetPoint(float t, Vector3[] p)
	{
		var a = 0.5f * (2f * p[1]);
		var b = 0.5f * (p[2] - p[0]);
		var c = 0.5f * (2f * p[0] - 5f * p[1] + 4f * p[2] - p[3]);
		var d = 0.5f * (-p[0] + 3f * p[1] - 3f * p[2] + p[3]);

		var pos = a + (b * t) + (c * t * t) + (d * t * t * t);

		return pos;
	}

	//private Vector3 GetPoint(float t)
	//{
	//	var p = ControlPoints;

	//	var a = 0.5f * (2f * p[1]);
	//	var b = 0.5f * (p[2] - p[0]);
	//	var c = 0.5f * (2f * p[0] - 5f * p[1] + 4f * p[2] - p[3]);
	//	var d = 0.5f * (-p[0] + 3f * p[1] - 3f * p[2] + p[3]);

	//	var pos = a + (b * t) + (c * t * t) + (d * t * t * t);

	//	return pos;
	//}
}
