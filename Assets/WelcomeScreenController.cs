using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScreenController : MonoBehaviour
{
    public float delayBeforeNextScene = 3.0f; // Time in seconds

    void Start()
    {
        Invoke("LoadNextScene", delayBeforeNextScene);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("WelcomeScene"); // Replace with your next scene name
    }
}
