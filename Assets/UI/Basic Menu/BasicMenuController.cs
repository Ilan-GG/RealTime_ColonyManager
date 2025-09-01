using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.UIElements;

public class BasicMenuController : MonoBehaviour
{

    public VisualElement ui;

    public Button upgradeButton;
    public Button exitButton;

    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
        // GameStats.Instance.menuState(true);

        
    }

    private void OnEnable()
    {
        upgradeButton = ui.Q<Button>("UpgradeButton");
        upgradeButton.clicked += OnUpgradeButtonClicked;

        exitButton = ui.Q<Button>("ExitButton");
        exitButton.clicked += OnExitButtonClicked;
    
    }

    private void OnUpgradeButtonClicked()
    {
       
    }

    private void OnExitButtonClicked()
    {
        gameObject.SetActive(false);
        GameStats.Instance.openMenu = false;
    }


}
