using UnityEngine;
using System.Runtime.InteropServices;
public class Link : MonoBehaviour 
{

	public void OpenYoutubeVideo()
	{

#if (!UNITY_EDITOR)
		openWindow("https://www.youtube.com/watch?v=hVRdKoxvruA");
#endif

	}
	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}