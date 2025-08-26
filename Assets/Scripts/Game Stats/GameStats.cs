using UnityEngine;
using System.Collections;

public class GameStats : MonoBehaviour
{

    public static GameStats Instance { get; private set; }

    // Turn Data

    public int TurnNumber = 0;
    [SerializeField] private float interval = 10f;
    private Coroutine TurnCoroutine;
    private bool isRunning = false;

    // Game Stats/Data

    public int Food = 0;
    public int FoodIncome = 0;

    public int Mineral = 0;
    public int MineralIncome = 0;

    public int TechParts = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
    }


    public void AddFood(int x)
    {
        Food += x;
        StatsViewer.Update.FoodText(Food, FoodIncome);

    }

    public void AdvanceTime()
    {
        TurnNumber += 1;
        // More Effects
        AddFood(FoodIncome);
    }

    // Time Simulation Part
    
    void Start()
    {
        AdvanceTime();
        StartSimulation();
    }

    public void StartSimulation()
    {
        if (!isRunning)
        {
            isRunning = true;
            TurnCoroutine = StartCoroutine(TimeAdvanceCR());
        }
    }

    public void StopSimulation()
    {
        if (isRunning)
        {
            isRunning = false;
            if (TurnCoroutine != null)
            {
                StopCoroutine(TurnCoroutine);
            }
        }
    }

    IEnumerator TimeAdvanceCR()
    {
        while (isRunning)
        {
            AdvanceTime();
            yield return new WaitForSeconds(interval);
        }
    }

    void OnDestroy()
    {
        StopSimulation();
    }
    
}
