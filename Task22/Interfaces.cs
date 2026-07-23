public interface ISearchable
{
    bool Search(string term);
}

public interface IPriceable
{
    double CalculatePrice();
    void ApplyDiscount(double percent);
}

public interface IPrintable
{
    void Print();
    string ShortSummary();
}