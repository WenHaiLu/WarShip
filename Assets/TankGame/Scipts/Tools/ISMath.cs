using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISMath : MonoBehaviour {

	static public float Random(ISRange range)
	{
		return UnityEngine.Random.Range (range.min,range.max);
	}


}

[System.Serializable]
public struct ISRange
{
	public float min,max;

	public ISRange(float max,float min)
	{
		this.min = max;
		this.max = min;


	}
}