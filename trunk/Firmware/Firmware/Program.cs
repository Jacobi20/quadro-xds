﻿using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Firmware {
	public class Program {

		public static void Main ()
		{
			Debug.Print("Starting...");
			Thread.Sleep(100);

			MMA7660	accel = new MMA7660();

			Debug.Print("Init...");
			accel.Init();


			while (true) {

				accel.Update();
				Debug.Print("A = " + accel.AccelX + " " + accel.AccelY + " " + accel.AccelZ );
				
				Thread.Sleep(500);
			}
			
			
			#if false
			ITG3200	gyro = new ITG3200();

			Debug.Print("Starting...");

			Thread.Sleep(1000);
			// Use ITG3200_ADDR_AD0_HIGH or ITG3200_ADDR_AD0_LOW as the ITG3200 address 
			// depending on how AD0 is connected on your breakout board, check its schematics for details

			gyro.init( ITG3200.ITG3200_ADDR_AD0_LOW ); 
  
			Debug.Print("Gyro calibrating...");
			  
			gyro.zeroCalibrate(2500, 2);
			  
			Debug.Print("Done.");

			while (true) {

				while (gyro.isRawDataReady()) {
     
					// Reads calibrated values in deg/sec    
					float x,y,z;

					gyro.readGyro( out x, out y, out z ); 
					Debug.Print("Gyro: " + x.ToString() + " "
										 + y.ToString()	+ " "
										 + z.ToString() );

					Thread.Sleep(500);
				}				

			}
			#endif
		}
	}
}
