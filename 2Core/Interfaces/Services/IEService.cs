namespace _2Core.Interfaces.Services;

public interface IEService
{
    Task< ApiGenericResult<CallApiDTO> > CallAPI( string insurance, string token );
}

public class CallApiDTO
{
    public string? name {get; set;}
    public string? taxid {get; set;}
    public string? travel_license {get; set;}
    public string? telephone {get; set;}
    public string? email {get; set;}
    public string? address_no {get; set;}
    public string? address_moo {get; set;}
    public string? address_building {get; set;}
    public string? address_soi {get; set;}
    public string? address_road {get; set;}
    public string? address_subdistrict {get; set;}
    public string? address_district {get; set;}
    public string? address_province {get; set;}
    public string? address_postcode {get; set;}
}

public class CallApiInput
{
    public string insurance {get; set;}
    public string token {get; set;}
}

[Serializable]
public class ApiGenericResult<T> where T : class
{
    public int code { get; set; } = 200;
    public int count { get; set; } = 0;
    public string message { get; set; } = "Success";
    public string messageAlt { get; set; } = "";
    public T results { get; set; }
}