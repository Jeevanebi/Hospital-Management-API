Welcome to Hospital Management API" 
 
To Test in Local :

1. Import the HospitalManagementDB to your Local Server
2. Visual Studio -> Tools -> Package Manager Console -> command "Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r"
3. update your DB Con string in Web.config

Endpoints :

   * POST: api/User(LOGIN) 
   * GET: api/User/ID(GET_USER_BY_ID)
   * POST: api/Appointment(ADD APPOINTMENT) 
   * GET: api/Appointment?userid=YOURID&date=YOURDATE(GET_APPOINTMENT_BY_DATE = yyyy-mm-dd)
   
-------------------------------------------------------------------------------------------   

 PayLoads:
   
   POST: api/User(LOGIN) :

   REQUEST
   {
      "username" : "string",
      "password" : "string"
   }
   
   RESPONSE
    {
    "Response": true,
    "Message": "User 'user3' Logged In !",
    "Data": {
        //All User Data
        }
    }

   POST: api/Appointment(ADD APPOINTMENT) :
   
   REQUEST
   {
      "userid" : int,
      "appointmentDate" : Date (yyyy-mm-dd),
      "appointmentTime" : Time(7) (HH:MM:SS.sssssss)
   }

   RESPONSE
   {
    "Response": true,
    "Message": "Appointment Created for the bas",
    "Data": {
        //Added Appointment details for the UserId
        }
    }
   
  --------------------------------------------------------- 
  
   External Packages to be Installed : -> NuGet
   
   EntityFramework - 6.4.4
   Newtonsoft.Json - 13.0.2
