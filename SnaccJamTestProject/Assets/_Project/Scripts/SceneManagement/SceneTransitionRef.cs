using UnityEngine;

[CreateAssetMenu()]
public class SceneTransitionRef : ScriptableObject
{
	[SerializeField]
	private SceneTransition _transitionPrefab;

	private SceneTransition _transition;

	private SceneTransition Transition
	{
		get
		{
			if(_transition == null)
			{
				_transition = Instantiate(_transitionPrefab);
				DontDestroyOnLoad(_transition);
			}

			return _transition;
		}
	}

	public void TransitionToScene(string sceneName, float inTime, float outTime)
	{
		Transition.TransitionToScene(sceneName, inTime, outTime);
	}
}
