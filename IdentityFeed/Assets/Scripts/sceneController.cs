using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneController : MonoBehaviour {
    public GameObject tweetPrefab;
    public static List<GameObject> allTweets;
	// Use this for initialization
	void Start () {
        
        allTweets = new List<GameObject>();
        for(int i = 0; i < 10; i++)
        {
            createNewTweet();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void createNewTweet()
    {
        GameObject newTweet = Object.Instantiate(tweetPrefab);
        newTweet.transform.parent = GameObject.Find("TweetScroler").transform;
        newTweet.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        allTweets.Add(newTweet);
        GameObject.Find("TweetScroler").GetComponent<RectTransform>().sizeDelta = new Vector2(500, 100 * allTweets.Count);
    }
}
