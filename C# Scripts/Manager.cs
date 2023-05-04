using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject exploration;
    public GameObject directions;
    public GameObject market;
    public GameObject settings;

	
    // Start is called before the first frame update
    void Start()
    {
        exploration.gameObject.SetActive(false);
        directions.gameObject.SetActive(false);
        market.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
    }

    public void Enable_directions()
    {
        directions.gameObject.SetActive(true);
        exploration.gameObject.SetActive(false);
        market.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
    }

    public void Enable_exploration()
    {
        directions.gameObject.SetActive(false);
        exploration.gameObject.SetActive(true);
        market.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
    }

    public void Enable_market()
    {
        directions.gameObject.SetActive(false);
        exploration.gameObject.SetActive(false);
        market.gameObject.SetActive(true);
        settings.gameObject.SetActive(false);
    }

    public void Enable_settings()
    {
        directions.gameObject.SetActive(false);
        exploration.gameObject.SetActive(false);
        market.gameObject.SetActive(false);
        settings.gameObject.SetActive(true);
    }

    public void Back()
    {
        directions.gameObject.SetActive(false);
        exploration.gameObject.SetActive(false);
        market.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);

    }
}
