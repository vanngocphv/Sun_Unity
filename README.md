# Program: SUN SIMULATOR
Program description: This program using for view the position of the Sun in specify datetime, latitude and longitude. Value of datetime, latitude and longitude has been received from User Input. <br />
Creator: NgocPHV <br />
Date Created: 09/06/2023 <br />
Date Finished: 10/06/2023 <br />

## Index contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Feature](#feature)
* [Setup](#setup)

## General info
From requirement: <br />
- This program involves taking user input and implementing the position of the sun based on the user's current location, date, and time <br />
- The pillar will be set with height same with human height (in this program, I set it has height is 2) <br />
- The light from Sun wil create a shadow behind the pillar <br />

Explain: <br />
- User can Input value for "Date", "Time", "Longitude", "Latitude" <br />
- The position of the sun should be implemented according to the user's input <br />
- The pillar has height = 2 <br />
- The pillar can cast shadow <br />
- The Sun will is Direction Light (basic Sun object of Unity) <br />

## Technologies
Project is created with:
* NugetPackage: CoordinateSharp [link](https://www.nuget.org/packages/CoordinateSharp/)
* Unity Asset: Customizable Skybox [link](https://assetstore.unity.com/packages/2d/textures-materials/sky/customizable-skybox-174576)
* Unity Editor Version: 2021.3.18f1

## Feature
(*User can rotate around the pillar, and look up and down for check the position of Sun*)

When open program, this program will show with value in left side:
* Latitude: 0, Longitude: 0
* Date: 10/03/2018, Time: 16:34 (4:34 PM)
* Return value of Sun Altitude: 24.5 
* Return value of Sun Azimuth: 265.7
(You can check this value in other website calculator for Sun Position)
![When the program open](./Images/BasicInfo.png)

![Basic Value](./Images/WhenOpen.png)

The Button Function:
* [Tab Button](#tab-button)
* [Arrow Button](#arrow-button)

![Button Function](./Images/ButtonUse.png)

### Tab Button
When click Tab button, the scene ask user input has been appeared, the value which has been set in this scene is basic value from the Left info
![When Tab button has been clicked](./Images/WhenClickTab.png)

User can change value in this scene
![Change value](./Images/ChangeValue.png)

If Change successfully, the scene will return a different Info value with the sun position has been set in different position
![Change successfully](./Images/ResultValue.png)

If change failed, the values don't valid, a message will be appeared
![Change failed](./Images/ChangeFailed.png)

### Arrow Button
This Left, Right Arrow (←, →)  button when clicked, the time will increase 1 hour. If hour > 24, days will increase by 1
* Current time
![Base Time](./Images/Basic.png)

* When click Left Arrow button (←)
![Time down 1 hour](./Images/TimeDown1Hours.png)

* When click Right Arrow button (→)
![Time up 1 hour](./Images/TimeUp1Hours.png)

## Setup
For using this program in your local computer, this is Guide:
* Step 1: Check your editor, this program has been build in Unity Editor 2021.3.18f1 <br />
![Build In](./Images/BuildIn.png)

* Step 2: Clone this project or zip it into your compute, next extract it (you need to install Git LFS for Large file, some time it will breaking image because tracking of the .gitattributes file) <br />
![Zip File](./Images/ZipFile.png) <br />
![Extract Zip file](./Images/Extract.png)

* Step 3: Create a new project in Unity 3D URP <br />
![New Project](./Images/NewProject.png)

* Step 4: Copy all file from extract file into this new Project, this is override some file in the project (Restart Unity if you already have it open) <br />
![Copy](./Images/Copy.png)
![Parse](./Images/Parse.png)
![Done](./Images/Done.png)

* Step 5: Open Scene "MainScene" <br />
![Choice Main Scene](./Images/ChoiceMainScene.png)

* Step 6: Run. <br />
