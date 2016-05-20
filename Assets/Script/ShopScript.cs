using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

	public int currLvl;
	public UserInput player;
	public WeaponScript weapons;
	public GameObject notEnough;
	public Text coinCount;

	public Button rifle;
	public Button shotgun;

	private int ammocost = 10;
	private int PRU = 50;
	private int RRU = 100;
	private int SRU = 150;
	private int PDU = 100;
	private int RDU = 150;
	private int SDU = 200;

	void Update(){
		coinCount.text = player.getGold ().ToString();
	}

	public void enterShopOnWin(HUDManager hud){
		currLvl = hud.getNextlvl();
		print (currLvl);
		print (hud.nextLevel);
		MenuScript.EnterShop ();
		if (weapons.getUnlocked ("rifle") == true) {
			rifle.interactable = false;
		}
		if (weapons.getUnlocked ("shotgun") == true) {
			shotgun.interactable = false;
		}
	}

	public void enterShopOnLose(HUDManager hud){
		currLvl = hud.getCurrlvl();
		MenuScript.EnterShop ();
		if (weapons.getUnlocked ("rifle") == true) {
			rifle.interactable = false;
		}
		if (weapons.getUnlocked ("shotgun") == true) {
			shotgun.interactable = false;
		}
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

	public int getRangeCost(string gun){
		if (gun == "pistol") {
			return PRU;
		}
		if (gun == "rifle") {
			return RRU;
		}
		if (gun == "shotgun") {
			return SRU;
		}
		return 0;
	}

	public int getDMGCost(string gun){
		if (gun == "pistol") {
			return PDU;
		}
		if (gun == "rifle") {
			return RDU;
		}
		if (gun == "shotgun") {
			return SDU;
		}
		return 0;
	}

	public void increaseRange(string gun){
		int tempGold = player.getGold ();
		if (tempGold - getRangeCost(gun) >= 0) {
			player.setGold(player.getGold () - getRangeCost (gun));
			weapons.incGunRange (gun);
		}
	}

	public void increaseDmg(string gun){
		int tempGold = player.getGold ();
		if (tempGold - getDMGCost (gun) >= 0) {
			player.setGold(player.getGold () - getDMGCost (gun));
			weapons.incGunRange (gun);
		}
	}

	IEnumerator killTime()
	{
		yield return new WaitForSeconds (20);
	}
}