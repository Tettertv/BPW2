using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GravitySwitch : MonoBehaviour{

	public static int Gravity = 1;

	void OnCollisionEnter2D(Collision2D col)
	{
		switch(col.gameObject.tag)
		{
			case "Up":
				Physics2D.gravity = new Vector2(0f, 9.81f);
				Gravity = 1;
				FindObjectOfType<AudioManager>().Play("GravitySwitch");
			break;
			case "Down":
				Physics2D.gravity = new Vector2(0f, -9.81f);
				Gravity = 1;
				FindObjectOfType<AudioManager>().Play("GravitySwitch");
			break;
			case "Left":
				Physics2D.gravity = new Vector2(-9.81f, 0f);
				Gravity = 2;
				FindObjectOfType<AudioManager>().Play("GravitySwitch");
			break;
			case "Right":
				Physics2D.gravity = new Vector2(9.81f, 0f);
				Gravity = 2;
				FindObjectOfType<AudioManager>().Play("GravitySwitch");
			break;
			case "EndGame":
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
				Physics2D.gravity = new Vector2(0f, -9.81f);
				Gravity = 1;
			break;
			case "Exit":
				Application.Quit();
			break;
		}
	}
}
