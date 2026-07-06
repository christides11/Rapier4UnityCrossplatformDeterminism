using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneSwitcher : MonoBehaviour
{
    public string sceneFallingColliders;
    public string sceneSimple;
    
    private async void Awake()
    {
        
    }

    public async void SWITCHTO_FallingColliders()
    {
        if(SceneManager.GetSceneByName(sceneSimple).IsValid()) SceneManager.UnloadSceneAsync(sceneSimple);
        await SceneManager.LoadSceneAsync(sceneFallingColliders, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneFallingColliders));
    }

    public async void SWITCHTO_Simple()
    {
        if(SceneManager.GetSceneByName(sceneFallingColliders).IsValid()) SceneManager.UnloadSceneAsync(sceneFallingColliders);
        await SceneManager.LoadSceneAsync(sceneSimple, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneSimple));
    }
}
