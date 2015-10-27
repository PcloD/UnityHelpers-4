using UnityEngine;
using System.Collections;

public class TestPath : MonoBehaviour
{
	private SplinePath path;

	void Awake()
	{
		path = GetComponent<SplinePath>();
	}

	// Update is called once per frame
	void Update()
	{
		path.TrackingPosition += Time.deltaTime;
	}
}


//float mag = 0f;
//foreach (var p in contrlPnts.Skip(1))
//{
//	mag = dist - trackingDist;
//	trackingDist += (p - prevPoint).magnitude;
//	nextPoint = p;
//	if (trackingDist >= dist)
//	{
//		Gizmos.DrawLine(prevPoint, p);
//		break;
//	}
//	prevPoint = p;
//}

	//0.6666667163372