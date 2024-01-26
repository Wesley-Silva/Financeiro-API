﻿using System.IdentityModel.Tokens.Jwt;

namespace WebApi.Token
{
    public class TokenJWT
    {
        private JwtSecurityToken token;

        public TokenJWT(JwtSecurityToken token)
        {
            this.token = token;
        }

        public DateTime ValidTo => token.ValidTo;

        public string valeu => new JwtSecurityTokenHandler().WriteToken(this.token);
    }
}
