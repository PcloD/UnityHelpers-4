using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SplinePath : MonoBehaviour
{
	[RangeAttribute(0, 1)]
	public float TrackingPosition = 0f;

	[RangeAttribute(1, 20)]
	public int Iterations = 10;

	public List<Vector3> ControlPoints
	{
		get
		{
			var points = GetComponentsInChildren<Transform>().Where(t => t != transform).Select(t => t.position).ToList();

			// Project the first point
			var pre = (points[0] - points[1]).normalized * 1 + points[0];
			points.Insert(0, pre);

			// project the last point
			var post = (points[points.Count - 1] - points[points.Count - 2]) * 1 + points[points.Count - 2];
			points.Add(post);

			return points;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;

		var controlPoints = ControlPoints;

		var prevControlPoint = controlPoints.First();
		for (int i = 0; i <= controlPoints.Count - 3; i++)
		{
			Gizmos.DrawWireSphere(controlPoints[i + 1], 0.5f);

			var prev = GetPoint(0, controlPoints.Skip(i).ToArray());
			
			var iterationStep = 1f / ((float)Iterations);
			for (var j = iterationStep; j < 1f; j += iterationStep)
			{
				var travelPoint = GetPoint(j, controlPoints.Skip(i).ToArray());
				Gizmos.DrawLine(prev, travelPoint);
				prev = travelPoint;
			}
			Gizmos.DrawLine(prev, GetPoint(1f, controlPoints.Skip(i).ToArray()));
		}

		Gizmos.DrawWireSphere(prevControlPoint, 0.5f);
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
}
