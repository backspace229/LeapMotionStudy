using UnityEngine;
using System.Collections;
using Leap;

public class GesturesTestScript : MonoBehaviour {

    // ジェスチャー検知に必要らしい
    private Controller controller = new Controller();

	// Use this for initialization
	void Start () {
        Debug.Log("Start Test");
        // ジェスチャー有効化らしい
        controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);
        controller.EnableGesture(Gesture.GestureType.TYPEKEYTAP);
        controller.EnableGesture(Gesture.GestureType.TYPESCREENTAP);
        controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
	}
	
	// Update is called once per frame
	void Update () {
        judgeGesture();
	}

    // ジェスチャーを判定する
    void judgeGesture()
    {
        Frame frame = controller.Frame();
        //int fingerCount = frame.Fingers.Count;    // サンプルに書いてあるくせに使ってない
        GestureList gestures = frame.Gestures();    // GestureListとはなんなのか
        //InteractionBox interactionBox = frame.InteractionBox; // サンプルに書いてあるくせに使ってない

        if (frame.Fingers[0].IsValid)
        {
            for (int i = 0; i < gestures.Count; i++)
            {
                Gesture gesture = gestures[i];
                switch (gesture.Type)
                {
                    case Gesture.GestureType.TYPECIRCLE:
                        var circleGesture = new CircleGesture(gesture);
                        Debug.Log(circleGesture);
                        Debug.Log("Circle");
                        break;

                    case Gesture.GestureType.TYPEKEYTAP:
                        var keytapGesture = new KeyTapGesture(gesture);
                        Debug.Log(keytapGesture);
                        Debug.Log("KeyTap");
                        break;

                    case Gesture.GestureType.TYPESCREENTAP:
                        var screentapGesture = new ScreenTapGesture(gesture);
                        Debug.Log(screentapGesture);
                        Debug.Log("ScreenTap");
                        break;

                    case Gesture.GestureType.TYPE_SWIPE:
                        var swipeGesture = new SwipeGesture(gesture);
                        Debug.Log(swipeGesture);
                        Debug.Log("Swipe");
                        break;

                    default:
                        break;
                }

            }
        }

    }
}
