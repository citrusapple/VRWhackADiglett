using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject moleContainer;
    public TextMesh infoText;
    public Player player;
    public float spawnDuration = 1.5f;
    public float spawnDecrement = 0.1f;
    public float minimumSpawnTime = 0.5f;
    private float spawnTimer = 0f;
    public float gameTimer = 15f;
    private float resetTimer = 3f;

    private Mole[] moles;

	// Use this for initialization
	void Start () {
        moles = moleContainer.GetComponentsInChildren<Mole>();
        
	}
	
	// Update is called once per frame
	void Update () {
        gameTimer -= Time.deltaTime;
        if (gameTimer > 0f)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                //rise new random mole
                moles[Random.Range(0, moles.Length)].Rise();

                //set a shorter time for the next mole to come
                spawnDuration -= spawnDecrement;

                //if it's getting too fast, we'll just keep it at time specified for minimum spawn
                if (spawnDuration < minimumSpawnTime)
                {
                    spawnDuration = minimumSpawnTime;
                }

                //change the timer to the new shorter time if it's not at minimum
                spawnTimer = spawnDuration;
            }
            infoText.text = "Whack The Digletts!\nTime: " + Mathf.Floor(gameTimer) + "\nScore:" + player.score;
        } else
        {
            infoText.text = "Game Over! Your score is " + player.score;
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
	}
}
