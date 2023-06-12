Markel Insurance Claims API

Solution:         Markel.DotNetCore.API
API project:      Insurance.Claims.API
                  This project presents the API call Action methods to access the Claims and the Company details.
Data project:     Insurance.Claims.Data
                  This project holds the Test data and the data access methods to return to the controller API calls via the respective service
Services project: Insurance.Claims.Servies
                  This project holds the business logic to be performed based on the API request and the data is accessed through the services
Abstractions:     Insurance.Claims.Abstractions
                  This project holds the interfaces to the Claims and the Company services. And also data models for the Claims and Company table structures
Test project:     Insurance.Claims.Test
                  This project holds the nUnit test cases to test the Company and the Claims business logic.
