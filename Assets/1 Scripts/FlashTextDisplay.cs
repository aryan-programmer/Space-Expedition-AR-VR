using UnityEngine;
using Utilities.Extensions;
public
class FlashTextDisplay : MonoBehaviour
{
	[SerializeField] float roamTime = 140, flashTextDisplayTime = 30;
	[SerializeField] GameObject movementDisabler;
	[SerializeField] TMPro.TextMeshProUGUI textMesh;
	[SerializeField] string flashTextTextFile =@"Texts\flashText"
	, textFormat =@"<size=1.25em><b>{0}</b></size>{1}"
	;
	private string[] flashTexts;
	public
	string[] FlashTexts
	{

		get
		{
			return flashTexts ?? ( flashTexts = Resources.Load<TextAsset>( flashTextTextFile ).text.Split( '\n' ) );


		}

	}
	Utilities.Timers.TimerWithExtraWaiting flashTextDisplayTimer;
	private
	void Start( )
	{
		textMesh.enabled = false;
		flashTextDisplayTimer =
		new Utilities.Timers.TimerWithExtraWaiting(
		roamTime , ShowTextAndWait ,
		delegate ( )
		{ movementDisabler.SetActive( !( textMesh.enabled = false ) );
		} );
		flashTextDisplayTimer.Start();

	}
	private
	float ShowTextAndWait( )
	{
		movementDisabler.SetActive( !( textMesh.enabled = true ) );
		string
		full = FlashTexts.GetRandomElement(),
		firstLetter = full.Substring( 0 , 1 ).ToUpper(),
		rest = full.Remove( 0 , 1 );
		textMesh.text = string.Format( textFormat , firstLetter , rest );
		Speaker.Speak( full );
		return flashTextDisplayTime;

	}
	private
	void OnDisable( )
	{
		textMesh.enabled = false;
		if(flashTextDisplayTimer != null)
		{
			flashTextDisplayTimer.Stopped = true;

		}

	}
	private
	void OnEnable( )
	{
		textMesh.enabled = false;
		if(flashTextDisplayTimer != null)
		{
			flashTextDisplayTimer.Stopped = false;
			flashTextDisplayTimer.Start();

		}

	}

}
