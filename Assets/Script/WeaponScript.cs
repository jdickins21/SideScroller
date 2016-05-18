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

	public void setUnlock(string gunName){
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

	public int getCost(string gunName){
		 if (gunName == "rifle") {
			return rifleCost;
		} else if (gunName == "shotgun") {
			return shotgunCost;
		} else {
			return 0;
		}

	}

	public void attemptPurchase(string gunName){
		if (player.loseMoney(getCost(gunName))){
			setUnlock(gunName);
			return;
		}
		print (player.getGold());
	}
}
