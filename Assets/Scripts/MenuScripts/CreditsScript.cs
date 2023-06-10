using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 20f;
    float timeLeft = 45.0f;
    public Animator transition;
    public float transitionTime = 1.0f;

    void Update()
    {
        transform.Translate(Camera.main.transform.up * scrollSpeed * Time.deltaTime);
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("MainMenu");
    }
}
