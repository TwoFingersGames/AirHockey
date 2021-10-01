
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLogic : MonoBehaviour
{
    public void OnePlayer()
    {
        SceneManager.LoadScene("SingleMode", LoadSceneMode.Single);
    }
    public void TwoPlayers()
    {
        
    }
    
}
