# Program: SUN_UNITY
Program description: This program using for view the position of the Sun in specify datetime, latitude and longitude. Value of datetime, latitude and longitude has been received from User Input.
Creator: NgocPHV
Date Created: 09/06/2023
Date Finished: 10/06/2023

## Index contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Feature](#feature)
* [Setup](#setup)

## General info
From requirement:
- This program involves taking user input and implementing the position of the sun based on the user's current location, date, and time
Explain:
- User can Input value for "Date", "Time", "Longitude", "Latitude"
- The position of the sun should be implemented according to the user's input

## Technologies
Project is created with:
* NugetPackage: CoordinateSharp [link](https://www.nuget.org/packages/CoordinateSharp/)
* Unity Asset: Customizable Skybox [link](https://assetstore.unity.com/packages/2d/textures-materials/sky/customizable-skybox-174576)
* Unity Editor Version: 2021.3.18f1

## Feature

When open, this program will show with value:
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

*When click Right Arrow button (→)
![Time up 1 hour](./Images/TimeUp1Hours.png)


