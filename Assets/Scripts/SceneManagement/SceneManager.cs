using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Signal loseSignal;

    private void Awake() {
        loseSignal.AddFunction(Lose);
    }

    public void Lose() {
        SceneManager.LoadScene("LoseScene");
    }

}
