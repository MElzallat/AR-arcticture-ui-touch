using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour {
    public GameObject mainCanvas;
    public Text textDesc;
    public string description = "Choose furniture from an inventory and put them any where in the house Using (Translation, Rotation, Scaling) with a single Touch";
    public float logoTimeDisplay = 2f;
    public float lettersTime = 0.08f;

	void Start () {
        StartCoroutine(enumerator());
    }

    IEnumerator enumerator() {
        if (PlayerPrefs.GetInt("ftp", 0) == 0)
        {
            //first time
            PlayerPrefs.SetInt("ftp", 1);
            yield return new WaitForSeconds(logoTimeDisplay);
            //show txt
            this.gameObject.GetComponent<Animator>().SetTrigger("start");
            yield return new WaitForSeconds(1f);
            foreach (char item in description)
            {
                textDesc.text += item;
                yield return new WaitForSeconds(lettersTime);
            }
        }
        else if (PlayerPrefs.GetInt("ftp", 0) == 1)
        {
            //second time
            yield return new WaitForSeconds(logoTimeDisplay);
            this.gameObject.GetComponent<Animator>().SetTrigger("close");
            yield return new WaitForSeconds(1f);
            this.gameObject.SetActive(false);
            mainCanvas.SetActive(true);
        }
        
    }

    public void btnDescClick()
    {
        StartCoroutine(enumerator2());
    }

    IEnumerator enumerator2()
    {
        this.gameObject.GetComponent<Animator>().SetTrigger("end");
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<Animator>().SetTrigger("close");
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
        mainCanvas.SetActive(true);
    }
}
