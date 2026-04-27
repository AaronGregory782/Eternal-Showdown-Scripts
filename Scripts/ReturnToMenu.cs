using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public void ReturnMenu()
    {
        SceneManager.LoadSceneAsync(1);

    }
    
}
