using UnityEngine;
public
class ShipMover : MonoBehaviour
{
	#region Unity Fields
	#pragma warning disable 0649
	[SerializeField] Transform path;
	[SerializeField] float movementTime, rotationTime;
	#pragma warning restore 0649
	#endregion
	int idx = -1;
	void Start( )
	{

		for(var i = 1; i <= path.childCount - 1; ++i )
		{
			path.GetChild( i - 1 ).LookAt( path.GetChild( i ).position );

		}
		path.GetChild( path.childCount - 1 ).LookAt( path.GetChild( 0 ).position );
		idx = 0;
		RotateAndMoveToNext();

	}
	void RotateAndMoveToNext( )
	{

		void MoveToNext( )
		{
			var waypoint = path.GetChild( idx = ( idx + 1 ) % path.childCount );
			LeanTween.move( gameObject , waypoint.position , movementTime ).setOnComplete( RotateAndMoveToNext );

		}
		LeanTween.rotateLocal( gameObject , path.GetChild( idx ).localEulerAngles , rotationTime ).setOnComplete( MoveToNext );

	}
	void OnDrawGizmos( )
	{

		for(var i = 1; i <= path.childCount - 1; ++i )
		{
			Gizmos.DrawLine( path.GetChild( i - 1 ).position , path.GetChild( i ).position );

		}
		Gizmos.DrawLine( path.GetChild( path.childCount - 1 ).position , path.GetChild( 0 ).position );

	}

}
