using UnityEngine;
using System.Collections;

[IntegrationTest.DynamicTest ("FaderTest")]
public class TestFadeOut : FaderTestBase
{
    int callbackCallCount = 0;

    void Start ()
    {
        Fader.Fade (FadeDirection.Out, () => {
            callbackCallCount += 1;
            var alpha = GUI.color.a;
            IntegrationTest.Assert (GUI.depth == Fader.drawDepth, "GUI Depth should be set");
            IntegrationTest.Assert (alpha == 1, "Alpha of the GUI color should be equal to 1 at the end of the fade");
            StartCoroutine (TestFaderAfterObjectRemoval (() => {
                IntegrationTest.Assert (callbackCallCount == 1, "Delegate callback was called more than once");
                IntegrationTest.Pass ();
            }));
        });
    }
}
