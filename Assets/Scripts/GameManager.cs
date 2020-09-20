using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    public Text score;
    public float slowness = 10f;
    public void EndGame () {
        StartCoroutine (RestartLevel ());
    }
    IEnumerator RestartLevel () {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        yield return new WaitForSeconds (1f / slowness);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
        Player.ScoreCount = 0;
    }
    public void SetScore () {
        Player.ScoreCount++;
        score.text = Player.ScoreCount.ToString ();
    }
}