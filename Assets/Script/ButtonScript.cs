using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	public bool active;
	public GameObject player;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	public void buttionAction(){

	}
}
