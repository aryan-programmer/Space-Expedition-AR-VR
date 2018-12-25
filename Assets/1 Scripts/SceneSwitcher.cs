public
class SceneSwitcher : UnityEngine.MonoBehaviour
{
	public
	enum SceneType
	{
		VR, ARVR

	}
	public static
	SceneType TypeOfScene
	{
		get;
		private set;

	}
	public
	void SwitchSceneVR( )
	{
		TypeOfScene = SceneType.VR;
		SwitchScene();

	}
	public
	void SwitchSceneARVR( )
	{
		TypeOfScene = SceneType.ARVR;
		SwitchScene();

	}
	void SwitchScene( )
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene( 1 );

	}

}
