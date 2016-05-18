using UnityEngine;
using System.Collections;

public class WeaponScript: MonoBehaviour  {

	public static bool pistolUnlocked = true;
	public static bool rifleUnlocked = false;
	public static bool shotgunUnlocked = false;
	public static int rifleCost = 25;
	public static int shotgunCost = 40;
	public string gunName;
	public UserInput player;

	public bool getUnlocked(string name){
		if (name == "pistol") {
			return pistolUnlocked;
		} else if (name == "rifle") {
			return rifleUnlocked;
		} else if (name == "shotgun") {
			return shotgunUnlocked;
		} else {
			return false;
		}
	}

	public void setUnlock(string name){
		if (name == "pistol") {
			return;
		} else if (name == "rifle") {
			rifleUnlocked = true;
		} else if (name == "shotgun") {
			shotgunUnlocked = true;
		} else {
			return;
		}
		print (pistolUnlocked + " " + rifleUnlocked + " " + shotgunUnlocked);
	}

	public int getCost(string name){
		 if (name == "rifle") {
			return rifleCost;
		} else if (name == "shotgun") {
			return shotgunCost;
		} else {
			return 0;
		}

	}

	public void attemptPurchase(string name){
		if (player.loseMoney(getCost(name))){
			setUnlock(name);
			return;
		}
	}
}
