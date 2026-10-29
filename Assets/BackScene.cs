using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonHandler : MonoBehaviour
{
    public string sceneToLoad = "WelcomeScene"; // Change to your desired scene

    public void GoBack()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
