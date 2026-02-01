using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Signal loseSignal;

    SceneManager sceneManager;

    private void Awake() {
        loseSignal.AddFunction(Lose);
    }

    public void Lose() {
        if (sceneManager != null) {
            Debug.Log("Lost");
            SceneManager.LoadScene("LoseScene");
        }
    }

}
