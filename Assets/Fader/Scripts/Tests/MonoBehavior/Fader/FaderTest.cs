using UnityEngine;
using System.Collections;

[IntegrationTest.DynamicTest ("FaderTest")]
public class FaderTest : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		Fader.Fade (FadeDirection.In, () => {
			var alpha = GUI.color.a;
			IntegrationTest.Assert (GUI.depth == Fader.drawDepth, "GUI Depth should be set");
			IntegrationTest.Assert (alpha == (int)FadeDirection.In, "Alpha of the GUI color should be equal to FadeDirection.In at the end of the fade");
			StartCoroutine (TestFaderObjectRemoval ());
		});
	}

	private IEnumerator TestFaderObjectRemoval ()
	{
		yield return new WaitForFixedUpdate ();
		IntegrationTest.Assert (GameObject.Find ("Fade") == null, "Fader game object should be removed at the end of fading");
		IntegrationTest.Pass ();
	}
}
