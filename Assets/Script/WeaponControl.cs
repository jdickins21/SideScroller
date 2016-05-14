using UnityEngine;
using System.Collections;

public class WeaponControl : MonoBehaviour {

	public AudioClip[] audioClip;
    public AudioSource source;
    public AudioClip gunChange;
	public GameObject[] weapons;
	public int weaponID = 0;

	public void SwitchWeaponUp()
	{
		weaponID++;
        source.PlayOneShot(gunChange, 1.0f);
        SwitchWeapon ();

    }

	public void SwitchWeaponDown()
	{
		weaponID--;
        source.PlayOneShot(gunChange, 1.0f);
        SwitchWeapon ();
    }

	public void SwitchWeapon()
	{
        
        if (weaponID > weapons.Length -1) 
		{
			weaponID = 0;
		}
		if (weaponID < 0) 
		{
			weaponID = weapons.Length -1;
		}

		Debug.Log (weaponID);

		if (weaponID == 0)
		{
			weapons [0].SetActive (true);
			weapons [1].SetActive (false);
			weapons [2].SetActive (false);
			GetComponent<AudioSource> ().clip = audioClip [0];
		}
		if (weaponID == 1)
		{
			weapons [0].SetActive (false);
			weapons [1].SetActive (true);
			weapons [2].SetActive (false);
			GetComponent<AudioSource> ().clip = audioClip [1];
		}
		if (weaponID == 2)
		{
			weapons [0].SetActive (false);
			weapons [1].SetActive (false);
			weapons [2].SetActive (true);
			GetComponent<AudioSource> ().clip = audioClip [2];
		}
    }
}
