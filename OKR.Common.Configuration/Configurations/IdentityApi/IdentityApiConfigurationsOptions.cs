
namespace OKR.Common.Configuration.Configurations.IdentityApi
{
    public class IdentityApiConfigurationsOptions
    {

        public string Host { get; set; } = null!;

        public EndPoints EndPoints { get; set; } = null!;
    }

    public class EndPoints
    {
        #region Identity
        public string Login { get; set; }
        public string Register { get; set; }
        #endregion

        #region Users
        public string GetAll { get; set; }
        #endregion
    }
}