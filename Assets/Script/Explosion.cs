using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour 
{

	void Awake () 
	{
		Destroy (this.gameObject, 0.25f);
	}
}
