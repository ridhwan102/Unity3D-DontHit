using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void GantiScene(int NoScene)
    {
        SceneManager.LoadScene(NoScene);
    }
}
