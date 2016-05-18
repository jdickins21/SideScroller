using UnityEngine;
using System.Collections;

public class MenuScript1 : MonoBehaviour {

	public int currLvl;


	public void enterShop(HUDManager hud){
		currLvl = hud.currLevel;
		MenuScript.EnterShop ();
	}

	public void exitShop(){
		MenuScript.ExitShop (currLvl);
	}
}
