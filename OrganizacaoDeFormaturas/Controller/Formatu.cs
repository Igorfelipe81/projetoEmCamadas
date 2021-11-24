using OrganizacaoDeFormaturas.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizacaoDeFormaturas.Controller
{
    public class Formatu
    {
        public int codigo { get; set; }
        public string nome { get; set; }

        public Conexao con;

        public Formatu()
        {
            con = new Conexao();
        }

        public void Criar()
        {
            try
            {
                con.ExecutarComando($"INSERT INTO `formatu`(`codigo`, `aluno`) VALUES (null,'{nome}')");
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na hora de cadastrar um formando " + e.Message);
            }
        }

        public DataTable Listar()
        {
            try
            {
                return con.ExecutarConsulta($"SELECT * FROM `formatu`");
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na hora de listar os formando " + e.Message);
            }
        }

        public void Editar()
        {
            try
            {
                con.ExecutarComando($"UPDATE `formatu` SET `aluno` = '{nome}' WHERE codigo = '{codigo}'");
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na hora de ediar o formando " + e.Message);
            }
        }

        public void Deletar(string codigo)
        {
            try
            {
                con.ExecutarComando($"DELETE FROM `formatu` WHERE `codigo` = '{codigo}'");
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na hora de deletar um estabelecimento " + e.Message);
            }
        }
    }
}
