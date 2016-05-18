using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WeaponControl : MonoBehaviour {

	public AudioClip[] audioClip;
	public List<SpriteRenderer> weapons = new List<SpriteRenderer>();
	public int weaponID = 0;

	public void SwitchWeaponUp()
	{
		weaponID++;
		SwitchWeapon ();
	}

	public void SwitchWeaponDown()
	{
		weaponID--;
		SwitchWeapon ();
	}

	public void SwitchWeapon()
	{
		if (weaponID >= weapons.Count) 
		{
			weaponID = 0;
		}
		if (weaponID < 0) 
		{
			weaponID = weapons.Count - 1;
		}

		if (weapons.Count == 1) 
		{
			if (weaponID == 0)
			{
				weapons [0].enabled = true;
				weapons [1].enabled = false;
				weapons [2].enabled = false;
				GetComponent<AudioSource> ().clip = audioClip [0];
			}
		}

		if (weapons.Count == 2) 
		{
			if (weaponID == 0)
			{
				weapons [0].enabled = true;
				weapons [1].enabled = false;
				weapons [2].enabled = false;
				GetComponent<AudioSource> ().clip = audioClip [0];
			}
			if (weaponID == 1)
			{
				weapons [0].enabled = false;
				weapons [1].enabled = true;
				weapons [2].enabled = false;
				GetComponent<AudioSource> ().clip = audioClip [1];
			}
		}

		if (weapons.Count == 3) 
		{
			if (weaponID == 0)
			{
				weapons [0].enabled = true;
				weapons [1].enabled = false;
				weapons [2].enabled = false;
				GetComponent<AudioSource> ().clip = audioClip [0];
			}
			if (weaponID == 1)
			{
				weapons [0].enabled = false;
				weapons [1].enabled = true;
				weapons [2].enabled = false;
				GetComponent<AudioSource> ().clip = audioClip [1];
			}
			if (weaponID == 2)
			{
				weapons [0].enabled = false;
				weapons [1].enabled = false;
				weapons [2].enabled = true;
				GetComponent<AudioSource> ().clip = audioClip [2];
			}
		}


	}
}
