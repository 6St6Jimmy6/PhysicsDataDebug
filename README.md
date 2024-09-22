Physics data debugger for Wreckfest.

    Launch the game

    Launch the debugger executable file after the game is on.

    Go in singleplayer and go in Banger Race alone without AI drivers

    You can monitor the tire physics and aero lift. There's also option for logging the data, tune what you log and you can also change some tire parameters on the fly.

    Press Start Logging and the debugger makes log files for each tire. It will log until you press the Stop Logging or close the program. You can also change the interval to be shorter or longer. By default it's 50ms, but that's not how fast the actual code runs... Minimum of 1 it likely runs about 30-50ms.

    Log files are located in C:\Users\USER_NAME\AppData\PhysicsDebugger\

    FrontLeftWreckfestDebugLog.txt for the front left tire

    FrontRightWreckfestDebugLog.txt for the front right tire

    RearLeftWreckfestDebugLog.txt for the rear left tire

    RearRightWreckfestDebugLog.txt for the rear right tire

    You can copy the text from the .txt files and they should be pasted correctly in Excel or whatever other program you use. By default semicolons ; are the delimiter separators, but you can also change it to something else through the settings.

    The Start Logging won't create new files if old ones exist. They just get recorded in the existing files then at the end of the file.
