using GestaoEquipamentos.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ConsoleApp.Controladores
{
    public class ControladorSolicitante:ControladorBase
    {
        public string RegistrarSolicitante(int id, string nomeSolicitante, string emailSolicitante, string numeroTelefoneSolicitante)

        {
            Solicitante solicitante = null;

            int posicao;

            if (id == 0)
            {
                solicitante = new Solicitante();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Solicitante(id));
                solicitante = (Solicitante)registros[posicao];
            }

            solicitante.nome = nomeSolicitante;
            solicitante.email = emailSolicitante;
            solicitante.telefone = numeroTelefoneSolicitante;
            

            string resultadoValidacao = solicitante.Validar();

            if (resultadoValidacao == "SOLICITANTE_VALIDO")
                registros[posicao] = solicitante;

            return resultadoValidacao;
        }

        public Solicitante SelecionarSolicitantePorId(int id)
        {
            return (Solicitante)SelecionarRegistroPorId(new Solicitante(id));
        }

        public bool ExcluirEquipamento(int idSelecionado)
        {
            return ExcluirRegistro(new Solicitante(idSelecionado));
        }

        public Solicitante[] SelecionarTodosEquipamentos()
        {
            Solicitante[] solicitanteAux = new Solicitante[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), solicitanteAux, solicitanteAux.Length);

            return solicitanteAux;
        }



    }
}
