Welcome to Hospital Management API" 
 
Endpoints :

   * POST: api/User(LOGIN) 
   * GET: api/User/ID(GET_USER_BY_ID)
   * POST: api/Appointment(ADD APPOINTMENT) 
   * GET: api/Appointment?userid=YOURID&date=YOURDATE(GET_APPOINTMENT_BY_DATE = yyyy-mm-dd)
   
-------------------------------------------------------------------------------------------   

 PayLoads:
   
   POST: api/User(LOGIN) :
   
   {
      "username" : "string",
      "password" : "string"
   }
   
   POST: api/Appointment(ADD APPOINTMENT) :
   
   {
      "userid" : int,
      "appointmentDate" : Date (yyyy-mm-dd),
      "appointmentTime" : Time(7) (HH:MM:SS.sssssss),
      "doctor" : "string"
   }
   
  --------------------------------------------------------- 
  
   External Packages to be Installed : -> NuGet
   
   EntityFramework - 6.4.4
   Newtonsoft.Json - 13.0.2
