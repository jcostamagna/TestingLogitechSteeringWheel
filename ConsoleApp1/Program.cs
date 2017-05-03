using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) { 
                Thread.Sleep(2000);
                LogitechGSDK.LogiSteeringInitialize(true);
                for (int i = 0; i < 1000000; i++)
             {
                    //All the test functions are called on the first device plugged in(index = 0) 
                    LogitechGSDK.LogiSteeringInitialize(true);
                    if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))
                {
                    if (LogitechGSDK.LogiIsPlaying(0, LogitechGSDK.LOGI_FORCE_SPRING))
                    {
                        LogitechGSDK.LogiStopSpringForce(0);
                    }
                    else
                    {
                        LogitechGSDK.LogiPlaySpringForce(0, 50, 50, 50);
                    }
                    }
                else
                {
                    LogitechGSDK.LogiPlayDirtRoadEffect(0, 100);
                }
            }
            Console.WriteLine("The program it's going to stop! ");
            LogitechGSDK.LogiSteeringShutdown();
            }
        }
    }
}
