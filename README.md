# zerobounce-dotnet-api-v1
This is a .Net wrapper class example for the ZeroBounce API v1.<br><br>
The .NET API Wrapper takes these input parameters.

|<b>Property</b>|<b>Values</b> 
|:--- |:--- 
apiKey  | Located in your account. 
emailToValidate | The email address your validating. 
ipAddress | [optional] The IP Address the email address was captured from 
requestTimeOut | [optional] Timeout settings in milliseconds, setting this enables you to control how long you are willing to wait for to send the request to the API. When the timeout occurs an "Unknown" result is returned. 
readTimeOut | [optional] Timeout settings in milliseconds, setting this enables you to control how long your willing to wait for the API to respond to your request. When the timeout occurs an "Unknown" result is returned.

The <b><i>ValidateEmail</b></i> and <b><i>GetCredit</b></i> methods return objects from which you can retrieve properties that return the relevant information.<br>

You can also easily consume and keep it updated within your Visual Studio Project with Nuget Package Manager:[ https://www.nuget.org/packages/ZeroBounceAPIWrapper/]( https://www.nuget.org/packages/ZeroBounceAPIWrapper/)

**Properties and possible values returned by:**
<b><i>ValidateEmail</b></i> method
  
|<b>Property</b>|<b>Possible Values</b> 
|:--- |:--- 
address  | The email address you are validating. 
status | Valid /Invalid /Catch-All /Unknown /Spamtrap /Abuse /DoNotMail 
subStatus  |antispam_system /greylisted /mail_server_temporary_error /forcible_disconnect /mail_server_did_not_respond /timeout_exceeded /failed_smtp_connection /mailbox_quota_exceeded /exception_occurred /possible_traps /role_based /global_suppression /mailbox_not_found /no_dns_entries /failed_syntax_check /possible_typo /unroutable_ip_address /leading_period_removed /does_not_accept_mail /alias_address
account | The portion of the email address before the "@" symbol.
domain | The portion of the email address after the "@" symbol
disposable |[true/false] If the email domain is diposable, which are usually temporary email addresses.
toxic |[true/false] These domains are known for abuse, spam, and bot created.
firstname | The first name of the owner of the email when available or [null].
lastname  |The last name of the owner of the email when available or [null].
gender |The gender of the owner of the email when available or [null].
creation date |The creation date of the email when available or [null].
location|The location of the owner of the email when available or [null].
country| The country of the IP passed in or [null].
region| The region of the IP passed in or [null].
city| The city of the IP passed in or [null].
zipcode| The zipcode of the IP passed in or [null]
processedat |The UTC time the email was validated.

<b><i>These additional properties are available when you set the ipAddress property.</b></i> method

|<b>Property</b>|<b>Possible Values</b> 
|:--- |:--- 
country  | The country the IP address is from. 
region | The state/region the IP address is from.
city | The city the IP address is from.
zipcode | The Zip Code the IP address is from. 

<b><i>GetCredit</b></i> method
  
|<b>Property</b>|<b>Possible Values</b> 
|:--- |:--- 
credits  | The number of credits left in account for email validation.

**Any of the following email addresses can be used for testing the API, no credits are charged for these test email addresses:**
+ disposable@example.com
+ invalid@example.com
+ valid@example.com
+ toxic@example.com
+ donotmail@example.com
+ spamtrap@example.com
+ abuse@example.com
+ unknown@example.com
+ catch_all@example.com
+ antispam_system@example.com
+ does_not_accept_mail@example.com
+ exception_occurred@example.com
+ failed_smtp_connection@example.com
+ failed_syntax_check@example.com
+ forcible_disconnect@example.com
+ global_suppression@example.com
+ greylisted@example.com
+ leading_period_removed@example.com
+ mail_server_did_not_respond@example.com
+ mail_server_temporary_error@example.com
+ mailbox_quota_exceeded@example.com
+ mailbox_not_found@example.com
+ no_dns_entries@example.com
+ possible_trap@example.com
+ possible_typo@example.com
+ role_based@example.com
+ timeout_exceeded@example.com
+ unroutable_ip_address@example.com

**You can this IP to test the GEO Location in the API.**

+ 99.110.204.1

<b>C# Example usage:<br></b>
```C#
 var zeroBounceAPI = new ZeroBounce.ZeroBounceAPI();

//set input parameters
zeroBounceAPI.apiKey = "Your API Key"; //Required
zeroBounceAPI.emailToValidate = "Email address your validating"; //Required
zeroBounceAPI.ipAddress = "IP address the email signed up with"; //Optional

//Depending on how you use the API, you might want it to time out faster, for example on a registration screen. 
//Normally the API will return results very fast, but a small percentage of mail servers take
//upwards of 20+ seconds to respond. 
//If the API times out, it will return a status of "Unknown" and a sub_status of "timeout_exceeded"  

zeroBounceAPI.readTimeOut = 200000;// "Any integer value in milliseconds
zeroBounceAPI.requestTimeOut = 150000; // "Any integer value in milliseconds

//validate email and assign results to an object
var apiProperties = zeroBounceAPI.ValidateEmail();

//check credits and assign results to an object
var apiCredits= zeroBounceAPI.GetCredits();

//use the properties to make decisions on
switch (apiProperties.status)
  {
      case "Invalid":
          Console.WriteLine("Invalid");
          break;
      case "Valid":
          Console.WriteLine("Valid");
          break;
      default:
          Console.WriteLine(apiProperties.status);
          break;
  }
```
<b>VB Example usage:<br></b>

```vbnet
Dim zeroBounceAPI = New ZeroBounce.ZeroBounceAPI

'set input parameters
zeroBounceAPI.apiKey = "Your API Key" '[Required] 
zeroBounceAPI.emailToValidate = "Email address your validating" '[Required] 
zeroBounceAPI.ipAddress = "IP address the email signed up with" '[Optional]

'Depending on how you use the API, you might want it to time out faster, for example on a registration screen. 
'Normally the API will return results very fast, but a small percentage of mail servers 
'take upwards of 20+ seconds to respond. 
'If the API times out, it will return a status of "Unknown" and a sub_status of "timeout_exceeded"  

zeroBounceAPI.readTimeOut = 200000 '[Optional] Any integer value in milliseconds 
zeroBounceAPI.requestTimeOut = 150000 '[Optional] Any integer value in milliseconds 


Dim apiProperties = zeroBounceAPI.ValidateEmail
Dim apiCredits = zeroBounceAPI.GetCredits

'use the properties to make decisions on
Select Case (apiProperties.status)
    Case "Invalid"
        Console.WriteLine("Invalid")
    Case "Valid"
        Console.WriteLine("Valid")
    Case Else
        Console.WriteLine(apiProperties.status)
End Select
```
