namespace AnticariApp.Application.User;

public class Address
{
    public string City { get; set; }

    public string Country { get; set; }

    public string StreetName { get; set; }

    public int? StreetNumber { get; set; }

    public string ZipCode { get; set; }

    public override string ToString()
    {
        if (City == "-")
        {
            return "-";
        }

        return $"{StreetName} nr. {StreetNumber}, {City}, {Country}, {ZipCode}";
    }
}
