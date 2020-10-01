using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItemsController : MonoBehaviour
{
    private int count;
    public int numberOfCollectibles;
    public TextMesh countText;
    private GameManager gm = GameManager.Instance;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        count = 0; //initialize counter
        UpdateUI();
    }

    /// <summary>
    /// When the player interacts with another object
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollectibleItemTag"))
        {
            count++;
            UpdateUI();            
            other.gameObject.SetActive(false); //disable and hide the collectible
        }
    }


    /// <summary>
    /// 
    /// </summary>
    private void UpdateUI()
    {
        //update UI
        countText.text = "Collected Items: " + count + " / " + numberOfCollectibles;

        //check if we have collected all items :)
        if (count == numberOfCollectibles)
        {   
            countText.text = "Congratz! \nYou have collected all items!";
            gm.GameStatus = GameManager.GameState.WON;
        }
    }
}
