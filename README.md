# CSharpSolutionTesting
This is an end to end example automation testing solution by using CSharp + NUnit (.net core) + Selenium WebDriver. 

The testing supports multiple browsers (current setting is for runing the testing with Chrome and Firefox).

Here are links of NUnit and Selenium

[NUnit](https://nunit.org/)

[Selenium](https://www.selenium.dev/documentation/en/)


## Prerequisites
+ Visual Studio 2019 (Windows version)
  
  Version: 16.7.7

+ Browsers 
  
  Chrome: Version 86.0.4240.111 

  Firefox: Version 82.0.2 

## Git clone the repo to local directory
```
cd /your/project/path
git clone https://github.com/MaxnzWZ/CSharpSolutionTesting.git (through https)
or
git clone git@github.com:MaxnzWZ/CSharpSolutionTesting.git (through ssh) 
``` 
## How to run test cases
### Open the project with Visual Studio (open KiwiSaverCalculatorTesting.sln)
![Open Project](images/openproject.JPG)

### Open test explore
![Open test exmplore](/images/opentestexplore.jpg)

### Build solution
![Build solution](images/buildSolution.jpg)

### Select test suites in test explore; right click and select Run to run testing
![Run selected test suite](images/selecttestsuitetorun.jpg)

### Check test result
#### Check summary of test result
![Check summary of the test result](images/testresultsummary.jpg)

#### Check failed test case
![Check failed reason message](images/checkerrormessage.jpg)

#### Check detailed information of failed test case
![Check details of the failed test case](images/checkfailuredetails.jpg)

#### Check screenshot of failed test case
![Check screenshot of failed test case](images/checkscreenshot.jpg)

#### Screenshots can be found in Screenshots under project folder
![Check screenshots in Screenshots under project folder](images/outputscreenshots.jpg)
