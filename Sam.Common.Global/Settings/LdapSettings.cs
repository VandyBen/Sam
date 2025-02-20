using Sam.Common.Global.Models;

namespace Sam.Common.Global.Settings;

// Not sure why I pulled this out.  But leaving it for now.
internal struct LdapSettingsSection
{
    public string Address { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Filter { get; set; }
    public string Uid { get; set; }
    public string GivenName { get; set; }
    public string Sn { get; set; }
    public string Mail { get; set; }
    public string VanderbiltPersonHrDeptName { get; set; }
    public string PhotoBaseUrl { get; set; }
}

public class LdapSettings
{
    private const string SectionName = "LdapSettings";
    private const string JsonFileName = "appsettings.json";
    private readonly LdapSettingsSection _ldapSettingsSection = new();

    public LdapSettings()
    {
        var configManager = new ConfigurationManager();
        configManager.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(JsonFileName);
        configManager.GetSection(SectionName).Bind(_ldapSettingsSection);
    }

    public LdapSettings(IConfiguration config)
    {
        config.GetSection(SectionName).Bind(this);
    }
    

#pragma warning disable CA1416   
    
    //
    //
    // This can only be run in Windows environment, so the "disable warning pragma" will let 
    // the compiler know we are aware.
    //
    //

    public UserInfo? GetPersonFromLdap(SearchResult searchResult) => SetPersonFromLdap(searchResult);
    
    
    private UserInfo? SetPersonFromLdap(SearchResult searchResult)
    {
        UserInfo? userInfo = null;
        if (searchResult.Properties.Count > 0 && searchResult.Properties.Contains(_ldapSettingsSection.Uid))
        {
            var vuNetId = GetValueFromLdap(searchResult, _ldapSettingsSection.Uid);
            var photoUrl = "";
            if (!string.IsNullOrEmpty(vuNetId))
            {
                photoUrl = string.Format(_ldapSettingsSection.PhotoBaseUrl, vuNetId);
            }

            var firstName = GetValueFromLdap(searchResult, _ldapSettingsSection.GivenName);
            var lastName = GetValueFromLdap(searchResult, _ldapSettingsSection.Sn);
            var emailAddress = GetValueFromLdap(searchResult, _ldapSettingsSection.Mail);
            var department = GetValueFromLdap(searchResult, _ldapSettingsSection.VanderbiltPersonHrDeptName);
            
            userInfo = new UserInfo(vuNetId, firstName, lastName, emailAddress, department, photoUrl);
        }
        return userInfo;
    }


    private string GetValueFromLdap(SearchResult? searchResult, string propertyName)
    {
        var value = string.Empty;
        if (null == searchResult || string.IsNullOrEmpty(propertyName)) return value;
        if (searchResult.Properties.Contains(propertyName))
        {
            value = $"{searchResult.Properties[propertyName][0]}";
        }
        return value;
    }
    
#pragma warning restore CA1416

    
}

