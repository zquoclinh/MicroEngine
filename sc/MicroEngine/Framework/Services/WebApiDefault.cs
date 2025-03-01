namespace MicroEngine.Framework.Services
{
    public class WebApiCommonDefaults
    {
        public static string LoginName = "LoginName";

        public static string UserName = "UserName";

        public static string UserCode = "UserCode";

        public static string BranchCode = "BranchCode";

        //
        // Summary:
        //     Gets user key of http context
        public static string UserKey => "neptuneApiUser";

        //
        // Summary:
        //     Gets Claim type
        public static string ClaimTypeName => "UserId";

        //
        // Summary:
        //     Gets the name of the header to be used for security
        public static string SecurityHeaderName => "Authorization";

        //
        // Summary:
        //     Token lifetime in days
        public static int TokenLifeTime => 7;

        //
        // Summary:
        //     The JWT token signature algorithm
        public static string JwtSignatureAlgorithm => "HS256";

        //
        // Summary:
        //     The minimal length of secret key applied to signature algorithm For HmacSha256
        //     it may be at least 16 (128 bites)
        public static int MinSecretKeyLength => 16;
    }
}
