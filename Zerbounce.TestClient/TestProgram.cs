﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Zerbounce.TestClient
{
    class TestProgram
    {
        static void Main(string[] args)
        {
            var zeroBounceAPI = new ZeroBounce.ZeroBounceAPI();
            zeroBounceAPI.ApiKey =  "Your API Key";
            zeroBounceAPI.EmailToValidate =  "Your Email Address";       
            zeroBounceAPI.IpAddress = "Your IP address";
            zeroBounceAPI.ReadTimeOut = 200000;// "Any integer value in milliseconds;
            zeroBounceAPI.RequestTimeOut = 150000; // "Any integer value in milliseconds;

            var apiProperties = zeroBounceAPI.ValidateEmail();
            if (apiProperties != null) { 
                PropertyInfo[] properties =  apiProperties.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    Console.WriteLine(property.Name + ": " + property.GetValue(apiProperties));
                }
            }

            //Check Credits
            zeroBounceAPI.ApiKey ="Your API Key";
            var apiCredits = zeroBounceAPI.GetCredits();
            if (apiCredits != null)
            {
                PropertyInfo[] properties = apiCredits.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    Console.WriteLine(property.Name + ": " + property.GetValue(apiCredits));
                }
            }
        }   
    }

}
