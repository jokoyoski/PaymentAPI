### Test Data

Below Data are Seeded in the Database
### Merchants
ID: 7d8d410e-34d1-11ee-be56-0242ac120002
Name: Amazon
IsActive: true
Code: CHK-1244O4I483
Merchant: Apple

ID: 830892be-34d1-11ee-be56-0242ac120002
Name: Apple
IsActive: true
Code: CHK-2939494944
Merchant: Samsung

ID: 830892be-34d2-11ee-be56-0242ac120002
Name: Samsung
IsActive: true
Code: CHK-2934494944


### Banks
Bank: HSBC
ID: 0017cd84-34d1-11ee-be56-0242ac120002
Bank Name: HSBC
IsActive: true
Sort Code: 000111


Bank: LLoyds
ID: 41724ce6-34d1-11ee-be56-0242ac120002
Bank Name: LLoyds
IsActive: true
Sort Code: 333444


### Currency
Currency: Naira (NAR)
ID: 41724ce6-34d1-11ee-be56-0242ac120002
Code: NAR
Name: Naira
Currency: Dollars (USD)

ID: 6a243ff0-34d1-11ee-be56-0242ac120002
Code: USD
Name: Dollars
Currency: Pounds Sterling (GBP)

ID: 715430b4-34d1-11ee-be56-0242ac120002
Code: GBP
Name: Pounds Sterling

### Card

5399-4155-0029-1626
CVV
089
Expiry Month
3
Experts Year
2027


5399415600301657
CVV
444
Expiry Month
3
Experts Year
2026


5399413603304457
CVV
222
Expiry Month
5
Experts Year
2033






### Database
Database is a cloud MSSQL Server.


### Response Code for Bank Simulator
Payment Response Codes
InvalidCard (Code: 4054)

Description: Indicates that the provided card information is invalid.
CVVNotOk (Code: 4055)

Description: Indicates that the CVV (Card Verification Value) provided is not valid.
CardExpired (Code: 4056)

Description: Indicates that the card has expired.
Timeout (Code: 4057)

Description: Indicates that the payment transaction has timed out.
CardBlacklisted (Code: 4058)

Description: Indicates that the card has been blacklisted and is not accepted.
InsufficientFunds (Code: 4059)

Description: Indicates that there are insufficient funds for the payment.
Successful (Code: 0000)

Description: Indicates a successful payment transaction.
CardOK (Code: 4060)

Description: Indicates that the card information is valid.
NotStarted (Code: 4062)

Description: Indicates that the payment transaction has not yet started.
PaymentBlocked (Code: 4062)

Description: Indicates that the payment transaction has been blocked.
BadTrackData (Code: 4063)

Description: Indicates that the track data of the payment is invalid.
DeclinedDoNotHonour (Code: 4064)

Description: Indicates that the payment is declined, do not honor the request.
UnknownErrorOccured (Code: 4065)

Description: Indicates that an unknown error has occurred during the payment process.



### Response Code for Payment API Gateway
Transaction Status Codes
TransactionCreated (Code: 5055)

Description: Indicates that a transaction has been created.
TransactionSuccessful (Code: 0000)

Description: Indicates a successful transaction.
TransactionFailed (Code: 5056)

Description: Indicates that a transaction has failed.

