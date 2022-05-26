# cb.automationpractice
Selenium C# UI Test for automationpractice.com

Project Build in VS 2022 Community 

Project Based on Nunit Framework

Selenium Version 4.1.1

Nunit Alure Reports (1.2.1.1)

Tested on chrome .

Support :

Crome , Edge , FireFox. 

Solution  devided to  two Projects :


cb.automationpractice.pages - For PageObject

cb.automationpractice.uitest - For UI Testing 

Reports:

to execute Alure Report need to install allure on local machine 

From PowerShell Execute : 

Set-ExecutionPolicy RemoteSigned -Scope CurrentUser

 scoop install allure
 
 from project folder run.
 allure serve allure-results
 
 ![2022-05-26 21_35_16-Allure Report](https://user-images.githubusercontent.com/34883695/170556433-885a323c-133e-44b6-856f-7f6531e092fa.png)

