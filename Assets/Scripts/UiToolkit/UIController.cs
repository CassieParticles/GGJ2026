using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject settings;
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
        playButton = ui.Q<Button>("Start");
        playButton.clicked += OnPlayButtonClicked;
        optionsButton = ui.Q<Button>("Settings");
        optionsButton.clicked += OnOptionsButtonClicked;
        quitButton = ui.Q<Button>("Exit");
        quitButton.clicked += OnQuitButtonClicked;
    }


    private void OnQuitButtonClicked()
    {
        Debug.Log("Quit");
        Application.Quit();

    }
    private void OnOptionsButtonClicked()
    {
        Debug.Log("Options");
        settings.SetActive(true);
        gameObject.SetActive(false);
    }
    private void OnPlayButtonClicked()
    {
        Debug.Log("");
        SceneManager.LoadSceneAsync(1);
        //gameObject.SetActive(false);
    } 
}
