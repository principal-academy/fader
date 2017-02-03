using UnityEngine;
using System.Collections;

/// <summary>
/// Represents the direction of the fader animation.
/// </summary>
public enum FadeDirection
{
    In = -1,
    Out = 1
}

/// <summary>
/// Fades the screen.
/// </summary>
public class Fader : MonoBehaviour
{
    /// <summary>
    /// Texture to be used to draw on the screen during fading.
    /// </summary>
    public Texture2D texture;

    /// <summary>
    /// Fade speed.
    /// </summary>
    public float speed = 0.8f;

    /// <summary>
    /// Fade delegate.
    /// </summary>
	public delegate void FadeDelegate ();

    /// <summary>
    /// Delegate to be called after fading.
    /// </summary>
    public FadeDelegate fadeDelegate;

    /// <summary>
    /// Depth of the drawn texture.
    /// </summary>
    public const int drawDepth = -1000;
    private float alpha = 1.0f;
    private FadeDirection direction = FadeDirection.Out;
    private new GameObject gameObject;
    private bool animationFinished = false;

    /// <summary>
    /// Fade the entire screen based on the direction.
    /// It creates a fader game object internally which is responsible for drawing the texture on the screen.
    /// </summary>
    /// <param name="direction">Fade direction.</param>
    /// <param name="fadeDelegate">Delegate to be executed after the fading is done.</param>
    public static void Fade (FadeDirection direction, FadeDelegate fadeDelegate = null)
    {
        var gameObject = new GameObject ("Fade");
        var fader = gameObject.AddComponent<Fader> ();
        fader.gameObject = gameObject;
        fader.alpha = direction == FadeDirection.In ? 1.0f : 0.0f;
        fader.texture = Resources.Load ("black") as Texture2D;
        fader.direction = direction;
        fader.fadeDelegate = fadeDelegate;
    }

    /// <summary>
    /// This is a Unity provided callback where the texture is drawn on the screen with changing alpha. 
    /// The fader game object is destroyed upon reaching the target alpha.
    /// </summary>
    void OnGUI ()
    {
        alpha += (int)direction * speed * Time.deltaTime;
        alpha = Mathf.Clamp01 (alpha);
        GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), texture);

        if (alpha == 0 || alpha == 1) {
            Destroy (gameObject);
            if (fadeDelegate != null && !animationFinished) {
                fadeDelegate ();
                animationFinished = true;
            }
        }
    }
}
