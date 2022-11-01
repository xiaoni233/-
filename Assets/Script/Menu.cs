using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioMixer audioMixer;

    public void QuitMain()  //退回主菜单
    {
        SceneManager.LoadScene(0);  //加载第几号场景，这里主菜单场景放在第一个，所以加载 0 号场景
    }
    public void PlayGame() //开始游戏
    {
        Time.timeScale = 1f; //重设时间流动，防止卡游
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //加载进入下一个场景,此处为第一关
    }
    public void QuitGame() //退出游戏
    {
        Application.Quit();//调用退出方法
    }
    public void UIEnableTrue() //加载开场主菜单动画后使用
    {
        GameObject.Find("Canvas/MainMenu/UI").SetActive(true); //调出ui
    }
        public void UIEnableFalse() //隐藏ui
    {
        GameObject.Find("Canvas/MainMenu/UI").SetActive(false);
    }
    public void PauseGame() //暂停游戏
    {
        pauseMenu.SetActive(true); //呼出暂停菜单,这里设置暂停菜单名字为 pauseMenu
        Time.timeScale = 0f; //游戏暂停时，调用暂停方法停止游戏时间从而停止游戏
    }
    public void ResumeGame() //继续游戏
    {
        pauseMenu.SetActive(false); //隐藏暂停菜单
        Time.timeScale = 1f; //恢复正常游戏时间流动
    }
    public void SetVolume(float value) //设置控制滑动条位置（接口）
    {
        audioMixer.SetFloat("MainVolume",value); //设置滑动条能控制的相关组件
    }
}
