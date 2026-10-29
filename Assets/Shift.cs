using UnityEngine;
using UnityEngine.SceneManagement;

public class ParticleSceneTransition : MonoBehaviour
{
    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (ps && !ps.IsAlive())
        {
            SceneManager.LoadScene("test"); // Replace with your next scene name
        }
    }
}
