using UnityEngine;
public
class WebCamDisplay : MonoBehaviour
{
	#pragma warning disable 0649
	[SerializeField] float scale = 100f;
	#pragma warning restore 0649
	private static WebCamTexture webCamTexture = null;
	void Start( )
	{

		if(webCamTexture == null)
		{
			webCamTexture = new WebCamTexture( WebCamTexture.devices[ 0 ].name );

		}
		GetComponent<Renderer>().material.mainTexture = webCamTexture;
		webCamTexture.Play();
		transform.localScale = new Vector3( webCamTexture.width / ( float ) ( webCamTexture.height ) , 1 , -1 ) * scale;
		transform.localPosition = new Vector3( 0 , 0 , scale * 5.4825f  );
		if(Application.isMobilePlatform)
		{
			transform.localScale = new Vector3( -transform.localScale.x , transform.localScale.y , transform.localScale.z );

		}

	}

}
