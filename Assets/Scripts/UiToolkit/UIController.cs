using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public VisualElement ui;

    public Button playButton;
    public Button optionsButton;
    public Button quitButton;
    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }
    private void OnEnable()
    {
        playButton = ui.Q<Button>("Play");
        playButton.clicked += OnPlayButtonClicked;
        optionsButton = ui.Q<Button>("Settings");
        optionsButton.clicked += OnOptionsButtonClicked;
        quitButton = ui.Q<Button>("Exit");
        quitButton.clicked += OnQuitButtonClicked;
    }


    private void OnQuitButtonClicked()
    {
        Application.Quit();

    }
    private void OnOptionsButtonClicked()
    {
        Debug.Log("Options");
    }
    private void OnPlayButtonClicked()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
