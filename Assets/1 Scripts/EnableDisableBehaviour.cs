using UnityEngine;
using System.Collections.Generic;
public
class EnableDisableBehaviour : MonoBehaviour
{
	[SerializeField] GameObject @object;
	[SerializeField] string type;
	Behaviour m_Behaviour;
	public
	Behaviour OBehaviour
	{

		get
		{
			return m_Behaviour ?? ( m_Behaviour = @object.GetComponent( type ) as Behaviour );


		}

	}
	public
	void OnDisable( )
	{
		OBehaviour.enabled = false;

	}
	public
	void OnEnable( )
	{
		OBehaviour.enabled = true;

	}

}
