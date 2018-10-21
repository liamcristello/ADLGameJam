using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTweet : MonoBehaviour {

	public TextAsset goodAdj;

	public TextAsset badAdj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	string buildTweet(string topic, int isPos, string madLib) {
		
		// Replace all '@' chars with adj
		// Replace all '$' with topic

		var result = madLib.Replace("$", topic);
		result = result.Replace("@", pullAdj(isPos));

		return result;
	}

	string newPosAdj() {
		string text = goodAdj.text;
		var splitText = text.Split('\n', ',');
		var randomIndex = Random.Range(0, splitText.Length);
		return splitText[randomIndex];
	}

	string newNegAdj() {
		string text = badAdj.text;
		var splitText = text.Split('\n', ',');
		var randomIndex = Random.Range(0, splitText.Length);
		return splitText[randomIndex];
	}

	string pullAdj(int isPos) {
		if (isPos > 0) {
			return newPosAdj();
		} else {
			return newNegAdj();
		}
	}


}
