using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class LoseUi : MonoBehaviour
{
    public VisualElement ui;

    public Button playButton;
    public Button optionsButton;
    public Button quitButton;
    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        playButton = ui.Q<Button>("Play");
        playButton.clicked += OnPlayButtonClicked;

        quitButton = ui.Q<Button>("Quit");
        quitButton.clicked += OnQuitButtonClicked;
    }


    private void OnQuitButtonClicked()
    {
        Debug.Log("Quit");
        SceneManager.LoadSceneAsync(0);

    }
    
    private void OnPlayButtonClicked()
    {
        Debug.Log("");
        SceneManager.LoadSceneAsync(1);
        //gameObject.SetActive(false);
    }
}
