# Payment API

## Introduction

To run the application, please ensure you have .NET installed, preferably .NET 7.

This application uses Swagger for API documentation and listens on:
http://localhost:5293/swagger/index.html

## Running the Application

1. Make sure you have .NET installed.
2. Navigate to `/PaymentAPI` directory.
3. Run the following command:
   ```bash
   dotnet run


## Running the Application With Docker

I have pushed the image on my Docker Hub Repository which gives access to anyone to run the code

Kindly navigate to the root directory of the project where docker compose stays and run 

 docker-compose up

This starts the app and listens on 

http://localhost:5293/swagger/index.html

## Running the Test
   
To run the tests, navigate to the root directory of the solution and execute the following command:

dotnet test




### Migrations Command 
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

As a result for my love in docker , the Cloud technology i woulf use for the deployment is Amazon ECS . The current config 
of this application is in appsettings.json that is somehow risky approach. The best approach would be to use Amazon Secret Manager to securely store sensitive configuration data, including database connection strings, API keys, and other confidential information. By doing so, I can effectively mitigate the risks associated with directly embedding these sensitive values in the application configuration.



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