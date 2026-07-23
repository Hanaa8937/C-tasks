using System;

public class VehicleNotFoundException : Exception
{
    public VehicleNotFoundException(string message) : base(message) { }
}

public class InvalidPriceException : Exception
{
    public InvalidPriceException(string message) : base(message) { }
}

public class StatusTransitionException : Exception
{
    public StatusTransitionException(string message) : base(message) { }
}