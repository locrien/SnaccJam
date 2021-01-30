using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PerspectiveSwitcher : MonoBehaviour
{
	public List<CinemachineVirtualCamera> Perspectives;

	private int _activeCam = 0;

	private void Awake()
	{
		foreach(var perspective in Perspectives)
		{
			perspective.gameObject.SetActive(false);
		}

		Perspectives[_activeCam].gameObject.SetActive(true);
	}
	
	void Update()
    {
		if(Input.GetKeyDown(KeyCode.LeftAlt))
		{
			Perspectives[_activeCam].gameObject.SetActive(false);
			_activeCam = (_activeCam + 1) % Perspectives.Count;
			Perspectives[_activeCam].gameObject.SetActive(true);
		}
    }
}
