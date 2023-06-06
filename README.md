# repetiva
Repetiva is a C# Selenium application that serves as a base for creating automated web site testing.

# Inspiration
This project was inspired after I developed my fifth application for testing websites using Selenium to remotely control a browser. I keep having to type the same starter code over and over. I finally decided to make it an open source project for others to use, contribute and advise to make it better. Enjoy!

# About the name
Repetiva is a spanish word which translates to repetitive in English. Since I found myself repeating the same starter code I might as well give an appropriate name.

However, testing is about doing something repetitive. Hence the name. If you find yourself testing the same thing across different browsers you might consider using an automated testing software like Selenium to perform those repetitive tasks.

Everything has a back story, feel free to clone and name it what is deemed appropriate for you.

# Instructions
To get your started with your own project name I have created the following notes to help get your copy up and running quickly.

* Install Visual Studio 2022
* Install Chrome (other browsers will be supported in the very near future).
* Chrome Version 114.0.5735.91 (Official Build) or higher is required.
* Clone the repo to your local drive:
```
git clone https://github.com/idrivediesel2006/repetiva.git [insert-folder-name-here]
```
* Open PowerShell with Admin Privileges
* Switch to folder where the repo was cloned
* Allow your user to execute PS scripts
```
Set-ExecutionPolicy RemoteSigned -Scope CurrentUser
```
* Execute ```rename-project.ps1``` to rename your whole solution including the namespace a name of your choice.
* Launch Visual Studio 2022
* [Right-Click] solution and select [Clean Solution]
* [Right-Click] solution and select [Rebuild]
* And finally press play

If everything worked as expected you find a screen shot of the search result in ```C:\temp\screenshot```

# Pending Improvements
* Add multiple browser support
* Create a demo test on a "real" site (does anyone have a site I can test with?)
* Add specific exceptions for unexpected behavior.

# Contact Me
 My Github profile has all my contact info. Feel free to shoot me a message.