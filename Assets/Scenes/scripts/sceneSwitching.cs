using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitching : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        globalVariable.currentPages = 0;
        globalVariable.monsterSpeed = 10;
        globalVariable.gameState = 0;
        SceneManager.LoadScene(scene);
    }
}
