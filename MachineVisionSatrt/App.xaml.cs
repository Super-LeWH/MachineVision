﻿using System.Configuration;
using System.Data;
using System.Windows;
using SharedResource; // 引用共享项目里的任意类型，用来取 Assembly

namespace MachineVisionSatrt
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // 显示启动画面
            ShowSplashScreen();
        }

        private void ShowSplashScreen()
        {
            // 这里要注意的点就是StartFlash.jpg 要设置为资源.
            var splash = new SplashScreen(typeof(SharedResource.SharedResourceConfig).Assembly, "Images/StartFlash.jpg");
            /*
             * 第一个参数表示是否自动关闭
             * 第二个参数表示启动画面窗口是否会被置于顶层,即使有其他程序的窗口处于活动状态,启动画面也会显示在它们之上.
             * 如果设置为false,表示遵循正常的窗口焦点规则,如果用户切换到其他程序,启动画面可能会被其他窗口遮挡.
             * 如果设置为true,保证用户一直能够看到它.
             */
            splash.Show(false, true);

            // 这里执行一些数据初始化的代码
            Task.Run(() =>
            {
                // 模拟耗时操作
                Thread.Sleep(1000);

                // 在UI线程上关闭启动画面
                Dispatcher.Invoke(() =>
                {
                    // 这里会有一个淡淡渐渐消失的效果
                    splash.Close(TimeSpan.FromSeconds(2));
                    // 启动主窗口
                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                    // 写入日志
                    Logging.Service.LogService.Info("程序启动");
                });
            });
        }
    }



}
