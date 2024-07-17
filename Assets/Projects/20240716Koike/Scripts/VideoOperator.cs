using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoOperator : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private float currentTime;

    public bool isHaruMode, isHagasuMode;
    private bool HaruModeDown;

    public float timeMoveSpeed;

    private float downPoint;
    public float haruMouseLength;

    private float lastMousePositionX;

    public enum Mode
    {
        Play,
        Haru,
        Hagasu
    };

    [SerializeField] private List<float> checkPoints = new List<float>();
    [SerializeField] private List<Mode> operateModes = new List<Mode>();
    public int currentSection;

    void Awake()
    {
        // VideoPlayerの準備が完了するのを待つ
        videoPlayer.prepareCompleted += OnVideoPlayerPrepared;
        videoPlayer.Prepare();

        isHagasuMode = false;
        lastMousePositionX = Input.mousePosition.x;
        HaruModeDown = false;

        currentSection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSection < checkPoints.Count)
        {
            if (videoPlayer.time > checkPoints[currentSection] && !isHagasuMode && !isHaruMode )
            {
                videoPlayer.Pause();
                currentSection++;
                if (operateModes[currentSection] == Mode.Hagasu)
                {
                    isHagasuMode = true;
                    isHaruMode = false;
                }
                else if (operateModes[currentSection] == Mode.Haru)
                {
                    isHagasuMode = false;
                    isHaruMode = true;
                }
            }


            if (isHagasuMode)
            {
                if (Input.GetMouseButton(0))
                {
                    if (Input.mousePosition.x < lastMousePositionX)
                    {
                        float diff = lastMousePositionX - Input.mousePosition.x;
                        videoPlayer.time += diff * timeMoveSpeed;

                        if (videoPlayer.time > checkPoints[currentSection])
                        {
                            videoPlayer.time = checkPoints[currentSection];
                            Debug.Log("replay");
                            isHagasuMode = false;
                            videoPlayer.Play();
                            currentSection++;
                        }
                    }
                }
            }

            if (isHaruMode)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    downPoint = Input.mousePosition.x;
                    HaruModeDown = true;
                }

                if (HaruModeDown && Input.GetMouseButton(0))
                {
                    float diff = Input.mousePosition.x - downPoint;
                    if (diff > haruMouseLength)
                    {
                        Debug.Log("replay");
                        isHaruMode = false;
                        videoPlayer.Play();
                        currentSection++;
                    }
                }

                if (Input.GetMouseButtonUp(0))
                {
                    HaruModeDown = false;
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