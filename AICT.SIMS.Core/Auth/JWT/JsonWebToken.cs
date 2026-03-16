namespace AICT.SIMS.Core.Auth.JWT
{
    public class JsonWebToken
    {
        public string? Token { get; set; }
        public DateTime ValidTo { get; set; }
        public long Expires { get; set; }
    }
}
