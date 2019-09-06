
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Drawing;

namespace GENXAPI.Utilities
{
    public enum JobExecutionStatus
    {
        [Description("Running")]
        Running = 1,
        [Description("Executed")]
        Executed = 2,
     
    }

    public enum TenderUtility
    {
        [Description("TenderState")]
        TenderState = 1,
        [Description("ContractState")]
        ContractState = 2,
        [Description("ContractApprovedState")]
        ContractApprovedState = 3,
        [Description("ContractCancelState")]
        ContractCancelState = 4,
        [Description("TenderRunningState")]
        TenderCancelState = 6,
        [Description("JobOrderState")]
        JobOrderState = 5,
        [Description("JobApprovalState")]
        JobApprovalState = 7,
        [Description("TenderCompleteState")]
        TenderCompleteState = 8,
    }
    public enum Status
    {
        [Description("Active")]
        Active = 1,
        [Description("In Active")]
        Inactive = 2,
        [Description("Deleted")]
        Deleted = 3,
        [Description("Pending")]
        Pending = 4,
        [Description("Paid")]
        Paid = 5,
        [Description("Unpaid")]
        Unpaid = 6,
    }
    public enum BillingMoths
    {
        [Description("January")]
        January = 1,
        [Description("Febuary")]
        Febuary = 2,
        [Description("March")]
        March = 3,
        [Description("April")]
        April = 4,
        [Description("May")]
        May = 5,
        [Description("June")]
        June = 6,
        [Description("July")]
        July = 7,
        [Description("August")]
        August = 8,
        [Description("September")]
        September = 9,
        [Description("October")]
        October = 10,
        [Description("November")]
        November = 11,
        [Description("December")]
        December = 12,

    }

    public enum Gender
    {
        [Description("Male")]
        Male = 1,
        [Description("In Female")]
        Female = 2
    }
    public static class Utility
    {
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }




        //public static Image Base64ToImage(string base64String)
        //{
        //    // Convert Base64 String to byte[]
        //    byte[] imageBytes = Convert.FromBase64String(base64String);
        //    MemoryStream ms = new MemoryStream(imageBytes, 0,
        //      imageBytes.Length);

        //    // Convert byte[] to Image
        //    ms.Write(imageBytes, 0, imageBytes.Length);
        //     Image image = Image.FromStream(ms, true);
        //    return image;
        //}
        
        public static Int32 GetAge(this DateTime dateOfBirth)
        {
            var today = DateTime.Now.Year;
            int age = today - dateOfBirth.Year;
            ////var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            ////var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            //return (a - b) / 10000;
            return age;
        }
        public static int GetDisCount(int DiscountAmt, double totalAmount)
        {
            if (DiscountAmt > 0)
            {
                return Convert.ToInt32((totalAmount / 100) * DiscountAmt);
            }
            else
            {
                return DiscountAmt;
            }
            
        }
    }
}