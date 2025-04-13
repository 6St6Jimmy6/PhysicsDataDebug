Physics data debugger for Wreckfest.

Main page:

![LiveData page](https://github.com/user-attachments/assets/c68f05b9-0a75-47ca-88be-779a9ff533a7)

This is how Four Wheels Page looks:

![limiters](https://github.com/user-attachments/assets/6036f3b7-04f2-46be-afed-c265f6ca7438)

![4wheels_gradient](https://github.com/user-attachments/assets/b9b06097-d5fb-41b0-ab7a-59061e778523)

This is how the G-Force graph looks by default:

![GForce Page](https://github.com/user-attachments/assets/9aa0afc9-47e5-4b50-b68b-cdd0e8f57d0d)

You can monitor many kind of physics. You can also limit the graphed data that's in the 4 Wheels page

There's option for logging the data, tune what you log and you can also change some tire parameters on the fly.

Press Start Logging and the debugger makes log files for each tire. It will log until you press the Stop Logging or close the program. You can also change the interval to be shorter or longer. By default it's 50ms, but that's not how fast the updates happen. You can see the tick speed under the box in milliseconds.

Log files are located in C:\Users\USER_NAME\AppData\PhysicsDebugger\
- FrontLeftWreckfestDebugLog.txt for the front left tire
- FrontRightWreckfestDebugLog.txt for the front right tire
- RearLeftWreckfestDebugLog.txt for the rear left tire
- RearRightWreckfestDebugLog.txt for the rear right tire

You can open the log files with the other program I made: https://github.com/6St6Jimmy6/Log-File-Reader-and-Plotter

You can also copy the text from the .txt files and they should be pasted correctly in Excel or whatever other program you use. By default semicolons ; are the delimiter separators, but you can also change it to something else through the settings.
The Start Logging won't create new files if old ones exist. They just get recorded in the existing files then at the end of the file.

Special thanks to:
- Cartoons for a nice help that I could find and confirm the first actual values from the memory and make it quick. Big kickstart for this project.
- N4T4NM and iGutobreks for the MemoryHelper and usage.
- Rod Stephens for the Registry Tools. Easy way to save settings.
