using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger1 : MonoBehaviour
{
    public string nextSceneName1;

    public void LoadNextScene1()
    {
        SceneManager.LoadScene("Order");
    }
}
