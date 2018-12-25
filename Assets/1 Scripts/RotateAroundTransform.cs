using UnityEngine;
public
class RotateAroundTransform: MonoBehaviour
{
	[System.Serializable]	struct TransformRotationAndSpeed
	{
		public string id;
		[SerializeField] internal Transform transform;
		[SerializeField] internal Vector3 rotation_axis;
		[SerializeField] internal float speed;
	}
	[SerializeField] TransformRotationAndSpeed[] transformsWithRotationAxesAndSpeeds;	void Update( )
	{
		for(var i = 0; i <= transformsWithRotationAxesAndSpeeds.Length - 1; ++i )
		{
			var curr = transformsWithRotationAxesAndSpeeds[ i ];
			curr.transform.RotateAround( transform.position , curr.rotation_axis , curr.speed );
		}

	}

}
