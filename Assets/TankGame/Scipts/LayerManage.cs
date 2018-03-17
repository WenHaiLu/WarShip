using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManage : MonoBehaviour {

	static public int redLayer = 16;
	static public int blueLayer = 17;
	static public int greenLayer = 15;

	static public LayerMask GetEnemyLayer(Team team)
	{
		LayerMask mask = 0;
		switch (team) {
		case Team.Blue:
			mask = (1 << redLayer | 1 << greenLayer);
			////
			break;

		case Team.Red:
			mask = (1 << blueLayer | 1 << greenLayer);
			////
			break;

		case Team.Green:
			mask = (1 << redLayer | 1 << blueLayer);
			////
			break;

		}
		return mask;
	}
}
