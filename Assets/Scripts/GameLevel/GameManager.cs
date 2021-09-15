using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject SpaceshipPrefab;
    public GameObject InGameScreenUI;
    public GameObject DeathScreenUI;
    public GameObject SpaceshipDestroyEffect;
    public GameObject AsteroidDestroyEffect;
    public AudioClip asteroidExplosionSound;
    public AudioClip spaceshipExplosionSound;
    public GameObject AsteroidPrefab;
    public Vector3 randomAsteroidPos;
    public Text inGameScoreText;
    public int inGameScore;
    public Text deathScreenScoreText;

    private void Start()
    {
        // Asteroid create function.
        StartCoroutine(CreateAsteroid());
    }

    private void Update()
    {
        // In game score text.
        inGameScoreText.text = inGameScore.ToString();
    }

    private void FixedUpdate()
    {
        // Skybox move.
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1);
    }

    public void GameOver()
    {
        deathScreenScoreText.text = inGameScore.ToString();
        this.GetComponent<AudioSource>().PlayOneShot(spaceshipExplosionSound);
        InGameScreenUI.SetActive(false);
        DeathScreenUI.SetActive(true);
    }
    
    IEnumerator CreateAsteroid()
    {
        yield return  new WaitForSeconds(1.5f);

        while (true)
        {
            for (int i = 0; i < 20; i++)
            {
                // Random create posstion.
                Vector3 vec = new Vector3(Random.Range(-randomAsteroidPos.x, randomAsteroidPos.x), randomAsteroidPos.y, randomAsteroidPos.z);

                // Create prefab.
                Instantiate(AsteroidPrefab, vec, Quaternion.identity);

                yield return new WaitForSeconds(0.7f);
            }
            yield return  new WaitForSeconds(1.5f);
        }
    }

    public void ExplosionAsteroid()
    {
        inGameScore++;
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(asteroidExplosionSound);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
