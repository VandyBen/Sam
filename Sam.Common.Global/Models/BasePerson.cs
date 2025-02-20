namespace Sam.Common.Global.Models;

public abstract class BasePerson
{
    private string _vuNetId = string.Empty;
    [Display(Name = "VuNetId")] 
    public string VuNetId
    {
        get => $"{_vuNetId}";
        set => _vuNetId = $"{value}".ToLower().Trim();
    }

    private string _firstName = string.Empty;

    [Display(Name = "First Name")]
    public string FirstName
    {
        get => $"{_firstName}"; 
        set => _firstName = $"{value}".Trim();
    }
    
    private string _lastName = string.Empty;
    [Display(Name = "Last Name")]
    public string LastName
    {
        get => $"{_lastName}";
        set => _lastName = $"{value}".Trim();
    }
    
    private string _email = string.Empty;
    [Display(Name = "Email Address")]
    public string EmailAddress
    {
        get => $"{_email}";
        set => _email = $"{value}".Trim().ToLower();
    }
    
    private string _department = string.Empty;
    [Display(Name = "Department")]
    public string Department
    {
        get => $"{_department}"; 
        set => _department = $"{value}".Trim();
    }


    private string _photo = string.Empty;
    [Url]
    [Display(Name = "PhotoUrl")]
    public string PhotoUrl
    {
        get => $"{_photo}"; 
        set => _photo = $"{value}".Trim().ToLower();
    }
}