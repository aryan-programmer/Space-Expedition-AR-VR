public
class ARVRObjectEnableControl : UnityEngine.MonoBehaviour
{
	[UnityEngine.SerializeField] bool enableWhenARVR;
	void Start( )
	{
		gameObject.SetActive( !( ( SceneSwitcher.TypeOfScene == SceneSwitcher.SceneType.ARVR ) ^ enableWhenARVR ) );

	}

}
