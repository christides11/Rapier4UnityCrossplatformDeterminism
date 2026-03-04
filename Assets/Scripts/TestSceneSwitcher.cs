using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneSwitcher : MonoBehaviour
{
    public string sceneFallingColliders;
    
    private async void Awake()
    {
        if (SceneManager.GetActiveScene().name != sceneFallingColliders)
        {
            await SceneManager.LoadSceneAsync(sceneFallingColliders, LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneFallingColliders));
        }
    }
}
