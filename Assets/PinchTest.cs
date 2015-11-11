using UnityEngine;
using System.Collections;
using Leap;

public class PinchTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Hand hand = new Hand();
        Debug.Log(hand.PinchStrength);
	}
}
