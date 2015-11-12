using UnityEngine;
using System.Collections;
using Leap;

public class Saiteigen : MonoBehaviour {

    // 絶対に必要
    Controller controller = new Controller();

    // 指の数をカウント
    public int FingerCount;
    public GameObject[] FingerObjects;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        // よくわからないけどこれも必要(なにしてるのかわからん)
        Frame frame = controller.Frame();
        FingerCount = frame.Fingers.Count;

        // 指が有効であればInteractionBoxオブジェクトを使って
        // LeapMotionの座標系をディスプレイ座標系に変換する
        InteractionBox interactionBox = frame.InteractionBox;

        Hand hand = frame.Hands.Rightmost;
        float strength = hand.GrabStrength;
        Debug.Log(strength);

        for (int i = 0; i < FingerObjects.Length; i++)
        {
            var leapFinger = frame.Fingers[i];
            var unityFinger = FingerObjects[i];
            SetVisiible(unityFinger, leapFinger.IsValid);
            if (leapFinger.IsValid)
            {
                Vector normalizedPoition = interactionBox.NormalizePoint(leapFinger.TipPosition);
                normalizedPoition *= 10;
                normalizedPoition.z = -normalizedPoition.z;
                unityFinger.transform.localPosition = ToVector3(normalizedPoition);
            }
        }
	}

    void SetVisiible(GameObject obj, bool visible)
    {
        foreach (Renderer component in obj.GetComponents<Renderer>())
        {
            component.enabled = visible;
        }
    }

    Vector3 ToVector3(Vector v)
    {
        return new UnityEngine.Vector3(v.x, v.y, v.z);
    }
}
