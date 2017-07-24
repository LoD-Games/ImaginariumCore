namespace ImaginariumCore.Contracts.Output
{
    public class TokenAndNickName
    {
        public string Token { get; }
        public string NickName { get; }

        public TokenAndNickName(string token, string nickName)
        {
            Token = token;
            NickName = nickName;
        }
    }
}
