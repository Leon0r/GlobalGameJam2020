
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// The Level Changer component loads either a specific level or the next in queue, adding a fade-out effect to it.
///	This component is meant to either be a singleton or be attached to a singleton gameObject. 
///	It is adviced that this component should be added to a persistent gameObject, so it gets carried with the scene change, since it is useful for every scene!
///	
/// This code was made using "How to Fade Between Scenes in Unity" Brackey´s video
/// https://www.youtube.com/watch?v=Oadq-IrOazg
/// </summary>
public class LevelChanger : MonoBehaviour {

	[Tooltip("Animator of this gameObject")]
	public Animator levelChangerAnimator;


	/// <summary>
	/// Index of the level we want to load with this script
	/// </summary>
	private int levelToLoad;


	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F))
		{
			FadeToNextLevel();
		}
	}

	/// <summary>
	/// Sets the fading trigger to "true", 
	/// and then sets the level we will load next
	/// </summary>
	/// <param name="levelIndex"></param>
	public void FadeToLevel (int levelIndex)
	{
		levelToLoad = levelIndex;
		levelChangerAnimator.SetTrigger("Fade_Out");
	}


	public void FadeToNextLevel()
	{
        AkSoundEngine.PostEvent("Start", gameObject);
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
	}

	/// <summary>
	/// When the fade effect ends
	/// </summary>
	public void OnFadeComplete()
	{
		levelChangerAnimator.SetTrigger("Fade_In");
        SoundManager.instance.ChangeState(SceneManager.GetActiveScene().buildIndex - 1);
		SceneManager.LoadScene(levelToLoad);
	}
}
