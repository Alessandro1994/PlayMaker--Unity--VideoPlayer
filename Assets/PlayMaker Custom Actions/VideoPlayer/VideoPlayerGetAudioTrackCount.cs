﻿// (c) Copyright HutongGames, LLC 2010-2017. All rights reserved.

#if UNITY_5_6_OR_NEWER

using UnityEngine;
using UnityEngine.Video;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VideoPlayer")]
	[Tooltip("Number of audio tracks found in the data source currently configured on a videoPlayer. For URL sources, this will only be set once the source preparation is completed. See VideoPlayer.Prepare.")]
	public class VideoPlayerGetAudioTrackCount : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VideoPlayer))]
		[Tooltip("The GameObject with as VideoPlayer component.")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Number of audio tracks found in the data source currently configured")]
		public FsmInt audioTrackCount;

		[Tooltip("Event sent if source is not prepared")]
		public FsmEvent isNotPrepared;

		GameObject go;

		VideoPlayer _vp;


		public override void Reset()
		{
			gameObject = null;
			audioTrackCount = null;
		}

		public override void OnEnter()
		{
			GetVideoPlayer ();

			ExecuteAction ();

			Finish ();
		}


		void ExecuteAction()
		{
			if (_vp != null)
			{
				if (_vp.isPrepared)
				{
					Fsm.Event (isNotPrepared);
					audioTrackCount = 0;
				} else
				{
					audioTrackCount = (int)_vp.audioTrackCount;
				}

				return;
			}
		}
			
		void GetVideoPlayer()
		{
			go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go != null)
			{
				_vp = go.GetComponent<VideoPlayer>();
			}
		}
	}
}

#endif