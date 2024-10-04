Physics data debugger for Wreckfest.

![alt text](https://private-user-images.githubusercontent.com/116525579/373574969-02d4c93b-d451-45c8-8d68-ab394e079281.PNG?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MjgwMzI0ODUsIm5iZiI6MTcyODAzMjE4NSwicGF0aCI6Ii8xMTY1MjU1NzkvMzczNTc0OTY5LTAyZDRjOTNiLWQ0NTEtNDVjOC04ZDY4LWFiMzk0ZTA3OTI4MS5QTkc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjQxMDA0JTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI0MTAwNFQwODU2MjVaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT0xYTUxNGEyZmZhMTRlYmNkMDcwZGM3ZjFiYjhkOTBlNjc3NzE3MTAwNWY4OWZjMzk5NWQ5OGI0YTg5YzA4MTBkJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCJ9.fgQJa6imn1ovqrbHpVBukByAb11thl7K3gW00FrAjG0)

    You can monitor many kind of physics. There's also option for logging the data, tune what you log and you can also change some tire parameters on the fly.

    Press Start Logging and the debugger makes log files for each tire. It will log until you press the Stop Logging or close the program. You can also change the interval to be shorter or longer. By default it's 50ms, but that's not how fast the updates happen. You can see the tick speed under the box in milliseconds.

    Log files are located in C:\Users\USER_NAME\AppData\PhysicsDebugger\

    FrontLeftWreckfestDebugLog.txt for the front left tire

    FrontRightWreckfestDebugLog.txt for the front right tire

    RearLeftWreckfestDebugLog.txt for the rear left tire

    RearRightWreckfestDebugLog.txt for the rear right tire

    You can open the log files with the other program I made: https://github.com/6St6Jimmy6/Log-File-Reader-and-Plotter

    You can also copy the text from the .txt files and they should be pasted correctly in Excel or whatever other program you use. By default semicolons ; are the delimiter separators, but you can also change it to something else through the settings.

    The Start Logging won't create new files if old ones exist. They just get recorded in the existing files then at the end of the file.
