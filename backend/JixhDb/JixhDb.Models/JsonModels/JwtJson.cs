namespace JixhDb.Models.JsonModels
{
    public class JwtJson
    {
        public JwtJson(string token)
        {
            this.Token = token;
        }

        public string Token { get; set; }
    }
}
