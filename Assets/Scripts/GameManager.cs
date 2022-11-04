using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject gameOver;
    [SerializeField] float sceneReloadTime = 2f;

    PipeSpawner pipeSpawner;
    PlayerMovement playerMovement;
    ForegroundScroll foregroundScroll;

    void Awake() 
    {
        pipeSpawner = FindObjectOfType<PipeSpawner>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        foregroundScroll = FindObjectOfType<ForegroundScroll>();
        Time.timeScale = 0f;
    }

    public void Play()
    {
        playButton.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        pipeSpawner.stopSpawn = true;
        playerMovement.isPlayerDead = true;
        foregroundScroll.stopScroll = true;

        // Finds all the instantiated pipes in scene
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        
        for(int i = 0; i < pipes.Length; i++)
        {
            pipes[i].isStopped = true;
        }

        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(sceneReloadTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
