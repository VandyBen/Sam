namespace Sam.Common.Global.Models;

public class UserInfo : BasePerson
{
    public bool IsWagAdmin { get; set; } = false;
    public int Id { get; set; } = 0;
    public DateTime? LastLoginDate { get; set; } = null;
    public int? LastListId { get; set; } = null;
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public string CreateUser { get; set; } = string.Empty;
    
    
    
    public UserInfo() { }

    
    public UserInfo
    (
        string vuNetId, 
        string firstName, 
        string lastName, 
        string email, 
        string department, 
        string photoUrl, 
        bool isWagAdmin = false, 
        int id = 0, 
        int? lastListId = null, 
        DateTime? lastLoginDate = null, 
        string createUser = "", 
        DateTime? createDate = null
        )
    {
        VuNetId = vuNetId;
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = email;
        Department = department;
        PhotoUrl = photoUrl;
        IsWagAdmin = isWagAdmin;
        Id = id;
        LastLoginDate = lastLoginDate;
        LastListId = lastListId;
        CreateDate = createDate ?? DateTime.Now;
        CreateUser = createUser;
    }
    
    
}