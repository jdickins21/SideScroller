using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

	public int currLvl;
	public UserInput player;
	public WeaponScript weapons;
	public GameObject notEnough;
	public Text coinCount;

	private int ammocost = 10;

	void Update(){
		coinCount.text = player.getGold ().ToString();
	}

	public void enterShopOnWin(HUDManager hud){
		currLvl = hud.getNextlvl();
		print (currLvl);
		print (hud.nextLevel);
		MenuScript.EnterShop ();
	}

	public void enterShopOnLose(HUDManager hud){
		currLvl = hud.getCurrlvl();
		MenuScript.EnterShop ();
	}

	public void exitShop(){
		MenuScript.ExitShop (currLvl);
	}

	public void attemptPurchase(string gun){
		int tempGold = player.getGold();
		if (tempGold - weapons.getCost (gun) >= 0) {
			player.setGold ((tempGold - weapons.getCost (gun)));
			weapons.setUnlock (gun);
			coinCount.text = player.getGold ().ToString();
		} else {
			notEnough.SetActive (true);
		//	print ("not enough");
			killTime();
			notEnough.SetActive (false);
		}
	}

	public void buyAmmo(string type){
		int tempGold = player.getGold ();
		if (tempGold - ammocost >= 0) {
			player.setGold (player.getGold () - ammocost);
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