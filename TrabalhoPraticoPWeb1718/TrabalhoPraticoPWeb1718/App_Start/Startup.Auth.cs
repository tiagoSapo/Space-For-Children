using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using System.Linq;
using TrabalhoPraticoPWeb1718.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using TrabalhoPraticoPWeb1718.Models.Perfis;
using System.Collections.Generic;
using TrabalhoPraticoPWeb1718.Models.ModelosBD;

namespace TrabalhoPraticoPWeb1718
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);


            // Aqui são criados os perfis
            CriarPerfis();
            AdicionaEnsinosEDisiciplinas();



            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
        private void CriarPerfis()
        {
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!RoleManager.RoleExists(Perfis.Pai))
            {
                var role = new IdentityRole();
                role.Name = Perfis.Pai;
                RoleManager.Create(role);
            }
            if (!RoleManager.RoleExists(Perfis.Admin))
            {
                var role = new IdentityRole();
                role.Name = Perfis.Admin;
                RoleManager.Create(role);
            }
            if (!RoleManager.RoleExists(Perfis.Instituicao))
            {
                var role = new IdentityRole();
                role.Name = Perfis.Instituicao;
                RoleManager.Create(role);
            }
            if (!RoleManager.RoleExists("Coisa"))
            {
                RoleManager.CreateAsync(new IdentityRole("Coisa"));
            }
        }
        private void AdicionaEnsinosEDisiciplinas()
        {
            if (!db.Ensinos.Any() && !db.Disciplinas.Any())
            {
                Disciplina d1 = new Disciplina { Nome = "Educação Musical", Curso = Curso.Artes };
                Disciplina d2 = new Disciplina { Nome = "Pintura", Curso = Curso.Artes };
                Disciplina d3 = new Disciplina { Nome = "Teatro", Curso = Curso.Artes };
 
                Disciplina d4 = new Disciplina { Nome = "Introdução ao Português", Curso = Curso.Letras };
                Disciplina d5 = new Disciplina { Nome = "Introdução à Matemática", Curso = Curso.Matematica };
                Disciplina d6 = new Disciplina { Nome = "Introdução ao Inglês", Curso = Curso.Letras };

                Disciplina d7 = new Disciplina { Nome = "Introdução ao Português", Curso = Curso.Letras };
                Disciplina d8 = new Disciplina { Nome = "Matemática", Curso = Curso.Matematica };
                Disciplina d9 = new Disciplina { Nome = "Estudo do Meio", Curso = Curso.Ciencias };
                Disciplina d10 = new Disciplina { Nome = "Inglês", Curso = Curso.Letras };

                Ensino e1 = new Ensino { Nome = "Creche" };
                Ensino e2 = new Ensino { Nome = "Pré-escolar" };
                Ensino e3 = new Ensino { Nome = "1º Ciclo" };

                e1.Disciplinas.Add(d1);
                e1.Disciplinas.Add(d2);
                e1.Disciplinas.Add(d3);
                d1.Ensino = e1;
                d2.Ensino = e1;
                d3.Ensino = e1;

                e2.Disciplinas.Add(d4);
                e2.Disciplinas.Add(d5);
                e2.Disciplinas.Add(d6);
                d4.Ensino = e2;
                d5.Ensino = e2;
                d6.Ensino = e2;

                e3.Disciplinas.Add(d7);
                e3.Disciplinas.Add(d8);
                e3.Disciplinas.Add(d9);
                e3.Disciplinas.Add(d10);
                d7.Ensino = e3;
                d8.Ensino = e3;
                d9.Ensino = e3;
                d10.Ensino = e3;


                db.Ensinos.Add(e1);
                db.Ensinos.Add(e2);
                db.Ensinos.Add(e3);

                db.Disciplinas.Add(d1);
                db.Disciplinas.Add(d2);
                db.Disciplinas.Add(d3);
                db.Disciplinas.Add(d4);
                db.Disciplinas.Add(d5);
                db.Disciplinas.Add(d6);
                db.Disciplinas.Add(d7);
                db.Disciplinas.Add(d8);
                db.Disciplinas.Add(d9);
                db.Disciplinas.Add(d10);

                db.SaveChanges();
            }

        }
    }
}