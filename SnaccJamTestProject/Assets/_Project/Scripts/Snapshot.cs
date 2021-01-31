using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Snapshot : MonoBehaviour
{
    // Start is called before the first frame update
    private IEnumerator Start()
    {
		yield return null;

		GetComponent<Camera>().Render();
		gameObject.SetActive(false);
    }
}
