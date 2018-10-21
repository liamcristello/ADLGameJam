using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class ReadTweet : MonoBehaviour {

	private HashSet<string> badWords;
	private HashSet<string> goodWords;
	


	// Use this for initialization
	void Start () {
		buildBadWords();
		buildGoodWords();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void buildBadWords() {

	}
	private void buildGoodWords() {

	}




	bool isBadword(string word) {
		return badWords.Contains(word);
	}

	bool isGoodword(string word) {
		return goodWords.Contains(word);
	}

	void readTweet(string userTweet) {
		val splitTweets = userTweet.Split(" ");
		foreach (string word in splitTweets) {
			if (isBadword(word))  { /*  */ }
			if (isGoodword(word)) { /*  */}
			// Else ignore the word
		}

	}


}
