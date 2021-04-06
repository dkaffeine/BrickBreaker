using UnityEngine.SceneManagement;

/// <summary>
/// Extra scene management - load extra scenes if they are not already loaded
/// </summary>

public static class ExtraScene
{
    public static bool IsSceneLoaded(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCount; ++i)
        {
            var scene = SceneManager.GetSceneAt(i);

            if (scene.name == sceneName)
            {
                //the scene is already loaded
                return true;
            }
        }
        //scene not currently loaded in the hierarchy:
        return false;
    }

    public static void Load(string sceneName)
    {
        if (IsSceneLoaded(sceneName) == false)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }

    public static void Unload(string sceneName)
    {
        if (IsSceneLoaded(sceneName) == true)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }

}
