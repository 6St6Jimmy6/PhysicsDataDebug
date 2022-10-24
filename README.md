Physics data debugger for Wreckfest October 2022 build.

- Launch the game
- Launch the debugger executable file
- Go in singleplayer and go in Banger Race alone without AI drivers
- You can monitor the tire physics and there's also option for logging the data
- Press Start Logging when the race timer has started. That way you get timestamps for better analyze. It will log until you press the Stop Logging or close the program. You can also change the interval to be shorter or longer. By default it's 50ms, but that's not how fast the actual code runs ;)
- Each of the four tires will have separate files
- Log files are located in C:\Users\USER_NAME\AppData\
- LocalFrontLeftWreckfestDebugLog.txt for the front left tire
- LocalFrontRightWreckfestDebugLog.txt for the front right tire
- LocalRearLeftWreckfestDebugLog.txt for the rear left tire
- LocalRearRightWreckfestDebugLog.txt for the rear right tire

- You can copy the text from the .txt files and they should be pasted correctly in Excel or whatever other program you use. ; are separators for columns

- The Start Logging won't create new files if old ones exist. They just get recorded in the existing files then at the end of the file.

- Here's for example how you can calculate the Lat/Lon fricitons from the log files:

- Lateral Friction = (Lateral Load)/(Vertical Load)
- Longitudinal Friction = (Longitudinal Load)/(Vertical Load)
