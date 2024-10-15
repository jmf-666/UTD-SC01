using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CanvasFader : MonoBehaviour, IFader {

	public Image img;
	public AnimationCurve curve;

	void Awake ()
	{
        GameManager.instance.OnFade += FadeTo;
    }

	public void FadeTo ()
	{
        StartCoroutine(FadeIn());
        StartCoroutine(FadeOut());
	}

	IEnumerator FadeIn ()
	{
		float t = 1f;

		while (t > 0f)
		{
			t -= Time.deltaTime;
			float a = curve.Evaluate(t);
			img.color = new Color (0f, 0f, 0f, a);
			yield return 0;
		}
	}

	IEnumerator FadeOut()
	{
		float t = 0f;

		while (t < 1f)
		{
			t += Time.deltaTime;
			float a = curve.Evaluate(t);
			img.color = new Color(0f, 0f, 0f, a);
			yield return 0;
		}
	}

}
