# Soap Endpoint Template

create an endpoint using SoapCore library that implements the <ClassNameHere> and the endpoint is at "</url>"


using the following SOAP Definition:


Create an automated test endpoint that executes the <endpoint> using playwright.



# Convert to use serviceModel
Make the following changes to the loggers.cs file:
The class no longer inherits from the System.Web.Services.WebService class so remove it.
Change the System.Web.Services.WebService attribute on the web service class to the System.ServiceModel.ServiceContract attribute.
Change the System.Web.Services.WebMethod attribute on each web service method to the System.ServiceModel.OperationContract attribute.
The class now uses the System.ServiceModel. 