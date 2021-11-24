using OrganizacaoDeFormaturas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizacaoDeFormaturas.Controller
{
    public static class Usuario
    {
        public static int codigo { get; set; }
        public static string email { get; set; }
        public static string senha { get; set; }
        public static Conexao con = new Conexao();
        public static void Criar()
        {
            try
            {
                con.ExecutarComando($"INSERT INTO `usuarios`(codigo, email, senha) VALUES (null,'{email}','{senha}')");
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na hora de cadastrar o usuário " + e.Message);
            }
        }
        public static bool Login()
        {
            var usuario = con.ExecutarConsulta($"SELECT * FROM usuarios WHERE email = '{email}' && senha = '{senha}'");

            if (usuario.Rows.Count > 0)
            {
                codigo = (int)usuario.Rows[0][0];

                return true;
            }

            return false;
        }
        public static void RedefinirSenha()
        {
            try
            {
                con.ExecutarComando($"UPDATE usuarios SET senha='{senha}' WHERE codigo='{codigo}'");
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na hora de mudar a senha! " + e.Message);
            }
        }
    }
}
