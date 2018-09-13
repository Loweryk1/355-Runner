using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SceneController))]

public class GUIController : MonoBehaviour {

    public Text scoreText;
    SceneController scene;

	// Use this for initialization
	void Start () {
        scene = GetComponent<SceneController>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + scene.score;
	}
    public void SliderValueChanged(float value)
    {
        print("DERP: " + value);
    }
}
