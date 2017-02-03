using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains helpful functions for testing Fader. Inherit your Dynamic Test from this class in order to use it.
/// </summary>
public class FaderTestBase : MonoBehaviour
{
    protected delegate void FaderTestBaseDelegate ();

    /// <summary>
    /// Tests that the Fader game object is removed at the next FixedUpdate.
    /// </summary>
    /// <returns>Enumerator that waits for FixedUpdate.</returns>
    /// <param name="baseDelegate">Delegate callback to call at the end of the test.</param>
    protected IEnumerator TestFaderAfterObjectRemoval (FaderTestBaseDelegate baseDelegate)
    {
        yield return new WaitForFixedUpdate ();
        IntegrationTest.Assert (GameObject.Find ("Fade") == null, "Fader game object should be removed at the end of fading");
        if (baseDelegate != null) {
            baseDelegate ();
        }
    }
}
