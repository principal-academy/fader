using UnityEngine;
using System.Collections;

[IntegrationTest.DynamicTest ("FaderTest")]
public class FaderTest : MonoBehaviour
{
    int callbackCallCount = 0;

    void Start ()
    {
        Fader.Fade (FadeDirection.In, () => {
            callbackCallCount += 1;
            var alpha = GUI.color.a;
            IntegrationTest.Assert (GUI.depth == Fader.drawDepth, "GUI Depth should be set");
            IntegrationTest.Assert (alpha == 0, "Alpha of the GUI color should be equal to 0 at the end of the fade");
            StartCoroutine (TestFaderAfterObjectRemoval ());
        });
    }

    private IEnumerator TestFaderAfterObjectRemoval ()
    {
        yield return new WaitForFixedUpdate ();
        IntegrationTest.Assert (GameObject.Find ("Fade") == null, "Fader game object should be removed at the end of fading");
        IntegrationTest.Assert (callbackCallCount == 1, "Delegate callback was called more than once");
        IntegrationTest.Pass ();
    }
}
