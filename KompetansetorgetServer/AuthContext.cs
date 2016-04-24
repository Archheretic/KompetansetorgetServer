using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using KompetansetorgetServer.Entities;

namespace KompetansetorgetServer
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("KompetansetorgetServerContext")
        {
        }

        /* Used for Client and RefreshTokens implementation. Which is not essential for this project at this moment.

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        */
    }
}