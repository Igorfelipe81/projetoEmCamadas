using OrganizacaoDeFormaturas.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizacaoDeFormaturas.Controller
{
    public class Lugar
    {
        public int codigo { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }



        public Conexao con;

        public Lugar()
        {
            con = new Conexao();
        }

        public void Criar()
        {
            try
            {
                con.ExecutarComando($"INSERT INTO `lugar`(`codigo`, `cep`, `endereco`) VALUES   (null,'{cep}','{endereco}')");
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na hora de cadastrar o local " + e.Message);
            }
        }

        public DataTable Listar()
        {
            try
            {
                return con.ExecutarConsulta($"SELECT * FROM `lugar`");
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na hora de listar o local " + e.Message);
            }
        }

        public void Editar()
        {
            try
            {
                con.ExecutarComando($"UPDATE `lugar` SET  `cep` = '{cep}' , `endereco` = '{endereco}' WHERE codigo = '{codigo}'");
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na hora de ediar o local " + e.Message);
            }
        }

        public void Deletar(string codigo)
        {
            try
            {
                con.ExecutarComando($"DELETE FROM `lugar` WHERE `codigo` = '{codigo}'");
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na hora de deletar o local" + e.Message);
            }
        }
    }
}