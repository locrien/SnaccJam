using UnityEngine;

public class SceneChanger : MonoBehaviour
{
	public string SceneName;

	public SceneTransitionRef Transition;

	public void ChangeScene()
	{
		Transition.TransitionToScene(SceneName, 1f, 1f);
	}
}
