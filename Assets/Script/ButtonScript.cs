using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour  {

	public static bool pistolUnlocked = true;
	public static bool rifleUnlocked = false;
	public static bool shotgunUnlocked = false;
	public string gunName;
	public GameObject player;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	public bool getUnlocked(string gunName){
		if (gunName == "pistol") {
			return pistolUnlocked;
		} else if (gunName == "rifle") {
			return rifleUnlocked;
		} else if (gunName == "shotgun") {
			return shotgunUnlocked;
		} else {
			return false;
		}
	}

	public void buttonAction(string gunName){
		if (gunName == "pistol") {
			return;
		} else if (gunName == "rifle") {
			rifleUnlocked = true;
		} else if (gunName == "shotgun") {
			shotgunUnlocked = true;
		} else {
			return;
		}
		print (pistolUnlocked + " " + rifleUnlocked + " " + shotgunUnlocked);
	}
}
