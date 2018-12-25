public
class LookAtCamera : UnityEngine.MonoBehaviour
{

	void Update( )
	{
		transform.LookAt( UnityEngine.Camera.main.transform );

	}

}
