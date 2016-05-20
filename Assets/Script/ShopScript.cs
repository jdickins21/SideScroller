using UnityEngine;
using System.Collections;

public class ShopScript : MonoBehaviour {

	public int currLvl;
	public UserInput player;
	public WeaponScript weapons;
	public GameObject notEnough;

	private int ammocost = 10;

	public void enterShopOnWin(HUDManager hud){
		currLvl = hud.nextLevel;
		MenuScript.EnterShop ();
	}

	public void enterShopOnLose(HUDManager hud){
		currLvl = hud.currLevel;
		MenuScript.EnterShop ();
	}

	public void exitShop(){
		MenuScript.ExitShop (currLvl);
	}

	public void attemptPurchase(string gun){
		int tempGold = player.getGold();
		if (tempGold - weapons.getCost (gun) > 0) {
			player.setGold ((tempGold - weapons.getCost (gun)));
			weapons.setUnlock (gun);
		} else {
			notEnough.SetActive (true);
		//	print ("not enough");
			killTime();
			notEnough.SetActive (false);
		}
	}

	public void buyAmmo(string type){
		int tempGold = player.getGold ();
		if (tempGold - ammocost > 0) {
			if (type == "rifle") {
				player.buyRammo ();
			}
			if (type == "shotgun") {
				player.buySammo ();
			}
		} else {
			notEnough.SetActive (true);
			//	print ("not enough");
			killTime();
			notEnough.SetActive (false);
		}
	}

	IEnumerator killTime()
	{
		yield return new WaitForSeconds (20);
	}
}