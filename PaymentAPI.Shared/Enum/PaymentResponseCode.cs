namespace PaymentAPI.Shared.Enum;

public enum PaymentResponseEnum
{
    InvalidCard = 4054,
    CVVNotOk = 4055,
    CardExpired = 4056,
    Timeout = 4057,
    CardBlacklisted = 4058,
    InsufficientFunds = 4059,
    Successful = 0000,
    CardOK = 4060,
    NotStarted = 4062,
    PaymentBlocked = 4062,
    BadTrackData = 4063,
    DeclinedDoNotHonour = 4064,
    UnknownErrorOccured = 4065
}
