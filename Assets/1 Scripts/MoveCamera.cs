using UnityEngine;
public
class MoveCamera : MonoBehaviour
{
	[SerializeField] float speed = 1;
	[SerializeField] GameObject @object;
	private
	void Update( )
	{
		transform.Translate( @object.transform.forward * speed * Time.deltaTime , Space.World );

	}

}
