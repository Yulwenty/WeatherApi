There are 2 applications:   
1.Web Api  
2.Web app to consume web Api  

This solution is REST api.  
Created with below technologies:  
1.N-Tier Architecture  
2.Framework .Net Core 3.1  
3.Authentication: API Key  
4.Auto Mapper  
5.Serilog for logging  
6.NUnit for Unit Test  
7.Mock  

Steps to run:  
1.Build and Run this solution using “WeatherApi” Profiles. It will open https://localhost:5001.   
Swagger page will automatically shown.    
ApiKey is NpGx1qn-32pNgwT-stBmK19-weCOP-kPBcx90 .   
It’s stored on appsetting.json with keyname: ApiKey  

2.Build & run  “WeatherForecast” web application to consume web api (use IISExpress profile).   
If you use different port than 5001 for web api, please set your new port  on appsetting.json with keyname: WeatherForecastClientBaseUrl  
