using UnityEngine;
public
class RandomizeEffectPositions : MonoBehaviour
{
	[SerializeField] Vector3 cubeSize;
	[SerializeField] GameObject[] effects;
	[ContextMenu( "InstantiateEffects" )]
	void InstantiateEffects( )
	{

		foreach(var effect in effects)
		{
			Instantiate( effect , GetRandomPos() , Quaternion.identity , transform );

		}

	}
	Vector3 GetRandomPos( )
	{
		var halfCube = cubeSize / 2;
		return transform.position +
		new Vector3(
		Random.Range( -halfCube.x , halfCube.x ) ,
		Random.Range( -halfCube.y , halfCube.y ) ,
		Random.Range( -halfCube.z , halfCube.z ) );

	}
	void OnDrawGizmos( )
	{
		Gizmos.DrawWireCube( transform.position , cubeSize );

	}

}
