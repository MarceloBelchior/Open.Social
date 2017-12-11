using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Open.Social.EF.SessionManager.Mapping
{
   public class UserMapping : EntityTypeConfiguration<Core.Model.User.User>
    {
        public UserMapping()
        {
            ToTable("Tbo_User");
            HasKey(t => t.id);
            Property(t => t.id).HasColumnName("UserId");
            Property(t => t.StatusEnum).HasColumnName("Status_Enun").IsRequired();
            Property(t => t.dt_lastaccess).HasColumnName("Dt_last_acess").IsRequired();
            //Property(t => t.data_ultimo_acesso).HasColumnName("Dt_last_acess").IsRequired();
            Property(t => t.Profile).HasColumnName("ProfileKey");
            Property(t => t.login).HasColumnName("login").HasMaxLength(50);
            Property(t => t.senha).HasColumnName("password").HasMaxLength(255);
            Property(t => t.salt).HasColumnName("Salt").HasMaxLength(255);
            Property(t => t.token).HasColumnName("TempToken");
            HasMany(T => T.ls_profile)
                .WithMany()
                .Map(T => T.ToTable("Tbo_User_Profile")
                    .MapLeftKey("UserId")
                    .MapRightKey("ProfileId"));
            Property(t => t.SocialMedia).HasColumnName("SocialMediaType");
            Property(t => t.SocialMediaId).HasColumnName("SocialMediaId");

            Ignore(c => c.CodData);
            Ignore(c => c.Message);
            Ignore(c => c.ValidData);

        }
    }
}