using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadScene("Beginning");
    }

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void Lose()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void ExitToGame() => Application.Quit();

    public Animator transition;

    public float transitionTime = 1f;

    public void LoadNextLevel(int Num)
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + Num));
    }

    IEnumerator LoadLevel(int levelIndex)
    {

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void Help()
    {
        SceneManager.LoadScene("Aisanff");
    }

     public void Babu()
    {
        SceneManager.LoadScene("Talkk");
    }

    public void Two()
    {
        SceneManager.LoadScene("TalkingWithOO");
    }

    public void Three()
    {
        SceneManager.LoadScene("Room");
    }

    public void Aisana()
    {
        SceneManager.LoadScene("Room");
    }

    public void Aul()
    {
        SceneManager.LoadScene("Aul");
    }
}
