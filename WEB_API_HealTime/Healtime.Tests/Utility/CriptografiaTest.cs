using WEB_API_HealTime.Utility;

namespace Healtime.Tests
{
    public class CriptografiaTest
    {
        [Fact]
        public static void ShouldCreatePasswordHash()
        {
            var password = "minhasenhamtsegura100%funcional";
            Criptografia.CriarPasswordHash(password, out byte[] hash, out byte[] salt);

            Assert.NotEmpty(hash);
            Assert.NotEmpty(salt);
        }
    }
}
