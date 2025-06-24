using Prorim_MediatrHandling.EntityRequests.Login.Requests;
using Prorim_MediatrHandling.EntityRequests.Login.Result;
using Prorim_MediatrHandling.Interfaces;
using Prorim_Services.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Login.Handlers
{
    public class GetLoginRequestHandler : IRequestHandler<GetLoginRequest, GetLoginResult>
    {
        private readonly IUserRepository _userRepository; 
        private readonly IConfiguration _config;
        public GetLoginRequestHandler(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public async Task<GetLoginResult> Handle(GetLoginRequest request, CancellationToken cancellationToken)
        {
            var doesUserExist = await _userRepository.GetByEmail(request.email);
            if(doesUserExist == null)
            {
                return null;
            }
            if (doesUserExist.password == request.password) 
            { 
                return new GetLoginResult() { accessToken = GenerateToken(doesUserExist), user = doesUserExist }; 
            };
            return null;
        }

        private string GenerateToken(TB_Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.id),
                new Claim(ClaimTypes.Role,user.role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(180),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}