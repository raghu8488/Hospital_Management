A Startup company who wants to build a highly scalable centralized platform to allow Hospitals,
Clinics and other Medical Institutions to store, retreive and manage Hospital & Patient’s records in their
Platform.
They are looking to build this as a API Based Platform through which any registered Tenant can connect
securely to this API and Manage the details of patients. To showcase how to integrate this API, they also want to
create a Simple UI using Blazor WASM Technology which consumes these API. So that other Hospitals can use
this as an Example for the actual Implementation.

Create a Web API (REST based) to Manage Patient and Patient Progress Notes
Should able to Search,Add,Update and Delete Patient Information

Should able to Add Progress Notes to Selected Patient

API Clients should not be allowed to access the API directly. They should use oAuth client_credentials to
Authorize and get the access tokens to start using the API.
This means there should exists a separate api to get the access tokens from the API. You can create a
separate table in db and prepoluate with few sample oAuth Client Ids.
OrganizationId : oAuth will use the ClientId to identify the OrganizationId. So in your API request you
SHOULD NOT Pass organization ID
