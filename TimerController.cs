using UnityEngine;

public class TimerController : MonoBehaviour
{
    public TextMesh timerText;
    public TextMesh countText;
    public float timeRemaining;
    public bool timerIsRunning = false;
    public GameObject collectibles;
    private GameManager gm = GameManager.Instance;

    // Start is called before the first frame update
    void Start()
    {     
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (gm.GameStatus == GameManager.GameState.WON)
            {
                timerIsRunning = false;
                timeRemaining = 0;
            }
            else if (gm.GameStatus == GameManager.GameState.PLAYING &&
                timeRemaining > 0)
            {
                //adjust time and update UI
                timeRemaining -= Time.deltaTime;
                UpdateUI(timeRemaining);                        
            }
            else //game over
            {
                gm.GameStatus = GameManager.GameState.LOST;

                //stop the game
                countText.text = "No more time - You lost the game";
                timerIsRunning = false;
                timeRemaining = 0;

                UpdateUI(timeRemaining);

                //hide the collectibles
                foreach (Transform obj in collectibles.transform)
                {
                    obj.gameObject.SetActive(false);
                }
            }
        }
    }

    private void UpdateUI(float timeRemaining)
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
