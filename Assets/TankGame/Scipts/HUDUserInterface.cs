using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDUserInterface : MonoBehaviour {

	public Unit player;
	public Image heathBar;
	public Text healthLabel;



	void Update () {
		heathBar.fillAmount = player.GetCurHealth () / player.health;
		healthLabel.text = player.GetCurHealth ().ToString ();

	}
}
