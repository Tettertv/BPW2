using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClick : MonoBehaviour
{
    float delay = .02f;
    public Vector3 Rotation;
    int z = 1;
    bool ready = true;
    bool hover = false;

    void Awake()
    {
        GetComponent<SpriteRenderer>().color = new Color (1f,1f,1f,0.1f);
	}

    void Update()
    {
        if(Input.GetKeyDown("mouse 0") && (ready) && (hover))
        {
            StartCoroutine(Spin(z, delay));
            ready = false;
            FindObjectOfType<AudioManager>().Play("Slide");
		}

        if(Input.GetKeyDown("mouse 1") && (ready) && (hover))
        {
            StartCoroutine(Spin(2, delay));
            ready = false;
            FindObjectOfType<AudioManager>().Play("Slide");
        }

        transform.eulerAngles = Rotation;
    }

    void OnMouseEnter()
    {
        hover = true;
        GetComponent<SpriteRenderer>().color = new Color (1f,1f,1f,1f);
	}

    void OnMouseExit()
    {
        hover = false;
        GetComponent<SpriteRenderer>().color = new Color (1f,1f,1f,0.1f);
	}

    IEnumerator Spin(int amount, float delay)
    {
        for (int i = 0; i < 90; i++)
        {
            if(amount == 1)
            {
                Rotation += new Vector3 (0, 0, 1);
            }else{
                Rotation -= new Vector3 (0, 0, 1);
			}
            yield return new WaitForSeconds(delay);
        }
        ready = true;
	}
}
