using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoOperator : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private float currentTime;

    public bool isOperateMode;

    public float timeMoveSpeed;
    private float lastMousePositionX;

    void Awake()
    {
        // VideoPlayerの準備が完了するのを待つ
        videoPlayer.prepareCompleted += OnVideoPlayerPrepared;
        videoPlayer.Prepare();

        isOperateMode = false;
        lastMousePositionX = Input.mousePosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(videoPlayer.time > 3.0f && videoPlayer.time <= 4.0f && !isOperateMode)
        {
            videoPlayer.Pause();
            isOperateMode = true;
        }

        if (isOperateMode)
        {
            if (Input.GetMouseButton(0))
            {
                if(Input.mousePosition.x > lastMousePositionX)
                {
                    float diff = Input.mousePosition.x - lastMousePositionX;
                    videoPlayer.time += diff * timeMoveSpeed;

                    if(videoPlayer.time > 6.0f)
                    {
                        videoPlayer.time = 6.0f;
                        Debug.Log("replay");
                        isOperateMode = false;
                        videoPlayer.Play();
                    }
                }
            }
        }

        currentTime = (float)videoPlayer.time;
        lastMousePositionX = Input.mousePosition.x;
    }

    private void OnVideoPlayerPrepared(VideoPlayer vp)
    {
        // VideoClipの長さを取得
        double videoLength = videoPlayer.length;
        Debug.Log("Video length: " + videoLength + " seconds");
    }
}