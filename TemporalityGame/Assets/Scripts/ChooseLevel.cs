using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour
{
    public void SetLevel(int level)
    {
        GameManager.instance.SetLevel(level);
        ManagerScene.instance.SetNumberSceneToChange(1);
        TransitionManager.instance.AnimateTransition();
    }
    public void MuteMusicManager()
    {
        MusicManager.instance.MuteMusic();
    }
    public void PlayButton()
    {
        SoundManager.instance.PlaySFX(SoundManager.instance.buttonSound);
    }
}
