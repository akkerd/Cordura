using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

    public string nameScene;
    public Color loadColor = Color.white;
    public float fadeSpeed;
	
	public void PlayGame ()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Initiate.Fade(nameScene, loadColor, fadeSpeed);
    }


} // cierre script
