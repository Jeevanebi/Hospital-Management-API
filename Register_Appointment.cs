//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalManagementAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class Register_Appointment
    {
        public int Appoitment_Id { get; set; }
        public Nullable<int> Register_Id { get; set; }
        public Nullable<System.DateTime> Appoitment_Date { get; set; }
        public string Appoitment_Time { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> Inserted_time { get; set; }
        public Nullable<int> FK_CustomerID { get; set; }
    }
}