using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    bool isHovering = false;
    public float timeToWait = 2f;
    float timeLeft;
    public static bool started = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Cursor") && !isHovering){
            timeLeft = timeToWait;
            isHovering = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Cursor"))
        {
            isHovering = false;
        }
    }

    void Update()
    {
        if (isHovering)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                isHovering = false;
                LoadGame();
            }
        }
    }

    public void LoadGame()
    {
        started = true;
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        Death.Set();
    }
    public void LoadGameOver()
    {

    }
    public void UnloadScene(int scene)
    {
        StartCoroutine(Unload(scene));
    }

    IEnumerator Unload(int scene)
    {
        yield return null;
        SceneManager.UnloadSceneAsync(scene);
    }
}
