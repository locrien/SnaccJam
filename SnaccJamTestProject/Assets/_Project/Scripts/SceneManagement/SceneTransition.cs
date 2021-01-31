using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class SceneTransition : MonoBehaviour
{
	private CanvasGroup _canvasGroup;

	private void Awake()
	{
		_canvasGroup = GetComponent<CanvasGroup>();
	}

	// Start is called before the first frame update
	public void TransitionToScene(string sceneName, float inTime, float outTime)
    {
		_canvasGroup.alpha = 0f;
		_canvasGroup.gameObject.SetActive(true);
		StartCoroutine(TransitionToSceneAsync(sceneName, inTime, outTime));
    }

	private IEnumerator TransitionToSceneAsync(string sceneName, float inTime, float outTime)
	{
		yield return FadeIn(inTime);

		yield return SceneManager.LoadSceneAsync(sceneName);

		yield return FadeOut(outTime);
	}

	public IEnumerator FadeIn(float time)
	{
		var startTime = Time.realtimeSinceStartup;

		_canvasGroup.alpha = 0f;
		_canvasGroup.gameObject.SetActive(true);

		float proportion = 0f;
		while (proportion <= 1f)
		{
			yield return new WaitForEndOfFrame();
			_canvasGroup.alpha = proportion;
			proportion = (Time.realtimeSinceStartup - startTime) / time;
		}

		_canvasGroup.alpha = 1f;
	}

	public IEnumerator FadeOut(float time)
	{
		var startTime = Time.realtimeSinceStartup;

		_canvasGroup.alpha = 1f;

		float proportion = 1f;
		while (proportion >= 0f)
		{
			yield return new WaitForEndOfFrame();
			_canvasGroup.alpha = proportion;
			proportion = 1 - ((Time.realtimeSinceStartup - startTime) / time);
		}

		_canvasGroup.alpha = 0f;
		_canvasGroup.gameObject.SetActive(false);
	}
}
