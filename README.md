Payment API Documentation
Introduction
This documentation provides comprehensive information about the Payment API. The API is designed to handle various aspects of payment processing, including merchant information, bank details, currency exchange, credit card transactions, and response codes.

To run the application, please ensure that you have .NET installed, preferably .NET 7. The API is documented using Swagger, and you can access the API documentation at:
http://localhost:5293/swagger/index.html

### Running the Application
To run the application locally:

Ensure you have .NET installed.
Navigate to the /PaymentAPI directory.
Run the following command:

dotnet run

This will start the application, and you can access the API documentation at the provided URL.



### Running the Application With Docker
For convenient deployment using Docker:

Adding...
Navigate to the root directory of the project where the docker-compose file is located.
Run the following command:

docker-compose up

This will start the application in a Docker container, and you can access the API documentation at:
http://localhost:5293/swagger/index.html



### Running Tests
To run the unit tests:

Navigate to the root directory of the solution.
Execute the following command:

dotnet test


### Database Migrations


If you want to play with the migrations or add more columns

Make sure you have Entity Framework tools installed globally. If not, run the following command to install them:

dotnet tool install --global dotnet-ef

To create and apply migrations, use the following commands:

dotnet ef migrations add Init --project InfrastructureProject -s APIProject
dotnet ef migrations add MerchantTable --project PaymentAPI.Data -s PaymentAPI




### Test Data
### Merchants
Here's the information presented in a tabular format:

| ID                                  | Name    | IsActive | Code           | Merchant  |
|-------------------------------------|---------|----------|----------------|-----------|
| 7d8d410e-34d1-11ee-be56-0242ac120002 | Amazon  | true     | CHK-1244O4I483 | Apple     |
| 830892be-34d1-11ee-be56-0242ac120002 | Apple   | true     | CHK-2939494944| Samsung   |
| 830892be-34d2-11ee-be56-0242ac120002 | Samsung | true     | CHK-2934494944| N/A       |

Below Data are Seeded in the Database

### Banks
Here's the information presented in a tabular format for the banks:

| ID                                  | Bank Name | IsActive | Sort Code |
|-------------------------------------|-----------|----------|-----------|
| 0017cd84-34d1-11ee-be56-0242ac120002 | HSBC      | true     | 000111    |
| 41724ce6-34d1-11ee-be56-0242ac120002 | LLoyds    | true     | 333444    |

Please let me know if you need any further assistance or if you have more data to include in the table.


### Currency
Here's the information presented in a tabular format for the currencies:

| ID                                  | Code | Name            |
|-------------------------------------|------|-----------------|
| 41724ce6-34d1-11ee-be56-0242ac120002 | NAR  | Naira           |
| 6a243ff0-34d1-11ee-be56-0242ac120002 | USD  | Dollars         |
| 715430b4-34d1-11ee-be56-0242ac120002 | GBP  | Pounds Sterling |

Please let me know if you need any further assistance or if you have more data to include in the table.

### Card

Here's the information you provided presented in a tabular format for credit card details:

| Card Number         | CVV  | Expiry Month | Expiry Year |
|---------------------|------|--------------|-------------|
| 5399-4155-0029-1626 | 089  | 3            | 2027        |
| 5399415600301657    | 444  | 3            | 2026        |
| 5399413603304457    | 222  | 5            | 2033        |

Feel free to let me know if you need any further assistance or if you have more data to include in the table.



### Database
Database is a cloud MSSQL Server.


### Response Code for Bank Simulator
Payment Response Codes
IHere's the information you provided presented in a tabular format for Payment Response Codes and Descriptions:

| Code   | Description                                                      |
|--------|------------------------------------------------------------------|
| 4054   | Indicates that the provided card information is invalid.         |
| 4055   | Indicates that the CVV (Card Verification Value) provided is not valid. |
| 4056   | Indicates that the card has expired.                             |
| 4057   | Indicates that the payment transaction has timed out.            |
| 4058   | Indicates that the card has been blacklisted and is not accepted. |
| 4059   | Indicates that there are insufficient funds for the payment.     |
| 0000   | Indicates a successful payment transaction.                     |
| 4060   | Indicates that the card information is valid.                   |
| 4062   | Indicates that the payment transaction has not yet started.      |
| 4062   | Indicates that the payment transaction has been blocked.         |
| 4063   | Indicates that the track data of the payment is invalid.         |
| 4064   | Indicates that the payment is declined, do not honor the request. |
| 4065   | Indicates that an unknown error has occurred during the payment process. |




### Response Code for Payment API Gateway

| Code   | Description                                      |
|--------|--------------------------------------------------|
| 5055   | Indicates that a transaction has been created.   |
| 5000   | Indicates a successful transaction.              |
| 5056   | Indicates that a transaction has failed.         |

If you need any further assistance or have more data to include, please let me know!



### Cloud Technology

Cloud Deployment
For cloud deployment, Amazon ECS is the chosen technology. The current configuration, which is stored in appsettings.json, can be enhanced for security by using Amazon Secret Manager to securely store sensitive data like database connection strings and API keys.

If you have any questions or need further assistance, please feel free to reach out!



Sample Payload 

{
  "cardNumber": "5399-4155-0029-1626",
  "merchantCode": "CHK-1244O4I483",
  "customerCode": "08080808088",
  "currencyCode": "NAR",
  "cvv": "089",
  "amount": 3000,
  "expiryMonth": 3,
  "expiryYear": 2027
}