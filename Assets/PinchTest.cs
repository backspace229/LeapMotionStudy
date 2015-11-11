using UnityEngine;
using System.Collections;
using Leap;

public class PinchTest : MonoBehaviour {
    Hand hand;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        hand = new Hand();
        Debug.Log(Mathf.Round(hand.PinchStrength * 100));
	}
}
