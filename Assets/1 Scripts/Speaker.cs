public static
class Speaker
{
	public static
	void Speak(string s)
	{
		#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
		WindowsVoice.Speak( s );
		#else
		InfinityEngine.Localization.SpeechEngine.Speak(s);
		#endif

	}

}
