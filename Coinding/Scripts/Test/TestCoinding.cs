using UnityEngine;
using System.Collections;

public class TestCoinding : MonoBehaviour {

	// Use this for initialization
	public void Start ()
	{
		Coinding.i.Developer.GetAll(onDevelopers, onError);
	}

	private void onError (string s)
	{
		Debug.LogError(s);
	}

	private void onDevelopers (JSONObject json)
	{
		Debug.Log(json.ToString());
	}
	
}
