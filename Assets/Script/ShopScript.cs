using UnityEngine;
using System.Collections;

public class ShopScript : MonoBehaviour {

	public int currLvl;


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


}