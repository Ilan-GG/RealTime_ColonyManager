using TMPro;
using UnityEngine;

public class StatsViewer : MonoBehaviour
{

    public static StatsViewer Update { get; private set; }

    void Awake()
    {
        if (Update == null)
        {
            Update = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public TMP_Text textSample;

    public void FoodText(int value, int income)
    {
        if (income >= 0)
        {
            textSample.text = string.Format("{0}(+{1})", value, income);
        }
        else
        {
            textSample.text = string.Format("{0}(-{1})", value, income);
        }

    }
}
